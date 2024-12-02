using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MobileInventory
{
    public partial class RecycleBinPage : UserControl
    {
        private SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MobileMart;Initial Catalog=MobileMart;Integrated Security=True");
        private Panel overlayPanel; // Declare the overlay panel
        public RecycleBinPage()
        {
            InitializeComponent();
            LoadRecycleBinData();
            overlayPanel = new Panel
            {
                Size = new Size(300, 300), // Size of the overlay panel
                BackColor = Color.White, // Background color for contrast (optional)
                Location = new Point((this.Width - 300) / 2, (this.Height - 300) / 2), // Center it
                Visible = false // Start off hidden
            };
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront(); // Ensure it's above other controls

            // Attach mouse event handlers to the RecycleBinViewGrid
            RecycleBinViewGrid.CellMouseEnter += ProductViewGrid_CellMouseEnter;
            RecycleBinViewGrid.CellMouseLeave += ProductViewGrid_CellMouseLeave;
        }
        private void ProductViewGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && RecycleBinViewGrid.Columns[e.ColumnIndex].Name == "ProductImage" && e.RowIndex >= 0)
            {
                string imagePath = RecycleBinViewGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    // Load the image and set it to be drawn in the overlay panel
                    overlayPanel.BackgroundImage = Image.FromFile(imagePath);
                    overlayPanel.BackgroundImageLayout = ImageLayout.Zoom; // Scale image to fit the panel
                    overlayPanel.Visible = true; // Show the overlay panel
                }
            }
        }

        private void ProductViewGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Hide the overlay panel when leaving the cell
            overlayPanel.Visible = false;
        }
        private void LoadRecycleBinData()
        {
            try
            {
                string query = "SELECT * FROM RecycleBinProducts";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                RecycleBinViewGrid.DataSource = dt;

                RecycleBinViewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                RecycleBinViewGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading recycle bin data: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBar.Text.Trim();
                string selectedCategory = cbCategoryFilter.SelectedIndex > -1 ? cbCategoryFilter.SelectedItem.ToString() : null;

                // Base query with optional category filter
                string query = @"SELECT ProductID, Category, ProductName, Price, Stocks, DateAdded, ProductImage
                         FROM RecycleBinProducts 
                         WHERE (ProductName LIKE @SearchText 
                         OR CAST(ProductID AS VARCHAR) LIKE @SearchText 
                         OR Category LIKE @SearchText)";

                // Add a filter for the selected category if one is chosen (but not "All")
                if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All")
                {
                    query += " AND Category = @Category";
                }

                // Add filter for month if the search text matches a valid month number
                if (int.TryParse(searchText, out int month) && month >= 1 && month <= 12)
                {
                    query += " OR MONTH(DateAdded) = @SearchMonth";
                }

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    // Add the category filter parameter if a specific category is selected
                    if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All")
                    {
                        command.Parameters.AddWithValue("@Category", selectedCategory);
                    }

                    // Add the search month parameter if applicable
                    if (int.TryParse(searchText, out month) && month >= 1 && month <= 12)
                    {
                        command.Parameters.AddWithValue("@SearchMonth", month);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    RecycleBinViewGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecycleBinViewGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show($"Please select one or{Environment.NewLine}more products to restore.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                connect.Open();
                SqlTransaction transaction = connect.BeginTransaction();

                foreach (DataGridViewRow row in RecycleBinViewGrid.SelectedRows)
                {
                    if (row.Cells["ProductID"].Value == null) continue;

                    int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
                    string category = row.Cells["Category"].Value.ToString();
                    string productName = row.Cells["ProductName"].Value.ToString();
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    int stocks = Convert.ToInt32(row.Cells["Stocks"].Value);
                    DateTime dateAdded = (DateTime)row.Cells["DateAdded"].Value;
                    string productImage = row.Cells["ProductImage"].Value?.ToString();

                    // Check if product exists in the Products table
                    string checkQuery = "SELECT Stocks FROM Products WHERE ProductName = @ProductName";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connect, transaction);
                    checkCommand.Parameters.AddWithValue("@ProductName", productName);

                    object result = checkCommand.ExecuteScalar();

                    if (result != null) // Product exists in Products
                    {
                        int existingStocks = Convert.ToInt32(result);
                        // Update the existing stock by adding the stocks from the RecycleBin
                        string updateQuery = "UPDATE Products SET Stocks = @Stocks WHERE ProductName = @ProductName";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connect, transaction);
                        updateCommand.Parameters.AddWithValue("@Stocks", existingStocks + stocks);
                        updateCommand.Parameters.AddWithValue("@ProductName", productName);
                        updateCommand.ExecuteNonQuery();
                    }
                    else // Product does not exist, insert it into Products
                    {
                        string insertQuery = "INSERT INTO Products (ProductID, Category, ProductName, Price, Stocks, DateAdded, ProductImage) " +
                                             "VALUES (@ProductID, @Category, @ProductName, @Price, @Stocks, @DateAdded, @ProductImage)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connect, transaction);
                        insertCommand.Parameters.AddWithValue("@ProductID", productID);
                        insertCommand.Parameters.AddWithValue("@Category", category);
                        insertCommand.Parameters.AddWithValue("@ProductName", productName);
                        insertCommand.Parameters.AddWithValue("@Price", price);
                        insertCommand.Parameters.AddWithValue("@Stocks", stocks);
                        insertCommand.Parameters.AddWithValue("@DateAdded", DateTime.Now);
                        insertCommand.Parameters.AddWithValue("@ProductImage", (object)productImage ?? DBNull.Value);

                        insertCommand.ExecuteNonQuery();
                    }

                    string deleteQuery = "DELETE FROM RecycleBinProducts WHERE ProductID = @ProductID";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connect, transaction);
                    deleteCommand.Parameters.AddWithValue("@ProductID", productID);
                    deleteCommand.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show($"Selected products {Environment.NewLine}restored successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRecycleBinData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error restoring products: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecycleBinViewGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show($"Please select one or more{Environment.NewLine}products to delete permanently.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                connect.Open();
                SqlTransaction transaction = connect.BeginTransaction();

                foreach (DataGridViewRow row in RecycleBinViewGrid.SelectedRows)
                {
                    if (row.Cells["ProductID"].Value == null) continue;

                    int productID = Convert.ToInt32(row.Cells["ProductID"].Value);

                    string deleteQuery = "DELETE FROM RecycleBinProducts WHERE ProductID = @ProductID";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connect, transaction);
                    deleteCommand.Parameters.AddWithValue("@ProductID", productID);
                    deleteCommand.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show($"Selected products {Environment.NewLine}deleted permanently!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRecycleBinData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting products: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void cbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cbCategoryFilter.Text;

            if (selectedCategory == "All")
            {
                LoadRecycleBinData();
            }
            else
            {
                FilterInventoryByCategory(selectedCategory);
            }
        }
        private void FilterInventoryByCategory(string category)
        {
            try
            {
                string query = "SELECT ProductID, Category, ProductName, Price, Stocks, DateAdded, ProductImage FROM RecycleBinProducts WHERE Category = @Category";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@Category", category);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    RecycleBinViewGrid.DataSource = dt;
                    RecycleBinViewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    RecycleBinViewGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
