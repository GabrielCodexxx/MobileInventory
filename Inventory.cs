using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileInventory
{
    public partial class Inventory : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MobileMart;Initial Catalog=MobileMart;Integrated Security=True");
        private Panel overlayPanel; 
        public Inventory()
        {
            InitializeComponent();
            LoadInventory();
            
            overlayPanel = new Panel
            {
                Size = new Size(300, 300), 
                BackColor = Color.White, 
                Location = new Point((this.Width - 300) / 2, (this.Height - 300) / 2), 
                Visible = false 
            };
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront(); 

            ProductViewGridInventory.CellMouseEnter += ProductViewGridInventory_CellMouseEnter;
            ProductViewGridInventory.CellMouseLeave += ProductViewGridInventory_CellMouseLeave;
        }
        private void ProductViewGridInventory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && ProductViewGridInventory.Columns[e.ColumnIndex].Name == "ProductImage" && e.RowIndex >= 0)
            {
                string imagePath = ProductViewGridInventory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    overlayPanel.BackgroundImage = Image.FromFile(imagePath);
                    overlayPanel.BackgroundImageLayout = ImageLayout.Zoom;
                    overlayPanel.Visible = true; 
                }
            }
        }

        private void ProductViewGridInventory_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            overlayPanel.Visible = false;
        }
        public void LoadInventory()
        {
            try
            {
                string query = "SELECT * FROM InventoryProducts";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ProductViewGridInventory.DataSource = dt;
                ProductViewGridInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ProductViewGridInventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}");
            }
        }
        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBar.Text.Trim();
                string selectedCategory = cbCategoryFilter.SelectedIndex > -1 ? cbCategoryFilter.SelectedItem.ToString() : null;

                string query = @"SELECT ProductID, Category, ProductName, Price, Stocks, DateAdded, ProductImage
                         FROM InventoryProducts 
                         WHERE (ProductName LIKE @SearchText 
                         OR CAST(ProductID AS VARCHAR) LIKE @SearchText 
                         OR Category LIKE @SearchText)";

                if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All")
                {
                    query += " AND Category = @Category";
                }

                if (int.TryParse(searchText, out int month) && month >= 1 && month <= 12)
                {
                    query += " OR MONTH(DateAdded) = @SearchMonth";
                }

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All")
                    {
                        command.Parameters.AddWithValue("@Category", selectedCategory);
                    }

                    if (int.TryParse(searchText, out month) && month >= 1 && month <= 12)
                    {
                        command.Parameters.AddWithValue("@SearchMonth", month);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    ProductViewGridInventory.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void RemoveProductsFromInventoryView(List<int> productIDs)
        {
            try
            {
                foreach (int productID in productIDs)
                {
                    foreach (DataGridViewRow row in ProductViewGridInventory.Rows)
                    {
                        if (row.Cells["ProductID"].Value != null &&
                            row.Cells["ProductID"].Value is int id &&
                            id == productID)
                        {
                            ProductViewGridInventory.Rows.Remove(row);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cbCategoryFilter.Text;

            if (selectedCategory == "All")
            {
                LoadInventory();
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
                string query = "SELECT ProductID, Category, ProductName, Price, Stocks, DateAdded, ProductImage FROM InventoryProducts WHERE Category = @Category";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@Category", category);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    ProductViewGridInventory.DataSource = dt;
                    ProductViewGridInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    ProductViewGridInventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductViewGridInventory.SelectedRows.Count == 0)
                {
                    MessageBox.Show($"Please select a product to send back to manage product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                List<int> productIDsToRemove = new List<int>();
                DataTable productData = new DataTable();
                productData.Columns.Add("ProductID");
                productData.Columns.Add("Category");
                productData.Columns.Add("ProductName");
                productData.Columns.Add("Price");
                productData.Columns.Add("Stocks");
                productData.Columns.Add("ProductImage");

                foreach (DataGridViewRow row in ProductViewGridInventory.SelectedRows)
                {
                    if (row.Cells["ProductID"].Value != null)
                    {
                        productData.Rows.Add(
                            row.Cells["ProductID"].Value,
                            row.Cells["Category"].Value,
                            row.Cells["ProductName"].Value,
                            row.Cells["Price"].Value,
                            row.Cells["Stocks"].Value,
                            row.Cells["ProductImage"].Value ?? DBNull.Value
                        );
                        productIDsToRemove.Add((int)row.Cells["ProductID"].Value);
                    }
                }

                using (SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MobileMart;Initial Catalog=MobileMart;Integrated Security=True"))
                {
                    connect.Open();
                    SqlTransaction transaction = connect.BeginTransaction();

                    try
                    {
                        foreach (DataRow dataRow in productData.Rows)
                        {
                            string checkQuery = "SELECT COUNT(*) FROM Products WHERE ProductName = @ProductName";
                            SqlCommand checkCommand = new SqlCommand(checkQuery, connect, transaction);
                            checkCommand.Parameters.AddWithValue("@ProductName", dataRow["ProductName"]);

                            int exists = (int)checkCommand.ExecuteScalar();

                            if (exists > 0)
                            {
                                string updateQuery = "UPDATE Products SET Stocks = Stocks + @Stocks, ProductImage = @ProductImage WHERE ProductName = @ProductName";
                                SqlCommand updateCommand = new SqlCommand(updateQuery, connect, transaction);
                                updateCommand.Parameters.AddWithValue("@Stocks", dataRow["Stocks"]);
                                updateCommand.Parameters.AddWithValue("@ProductName", dataRow["ProductName"]);
                                updateCommand.Parameters.AddWithValue("@ProductImage", dataRow["ProductImage"] ?? DBNull.Value);
                                updateCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                string insertQuery = "INSERT INTO Products (ProductID, Category, ProductName, Price, Stocks, DateAdded, ProductImage) VALUES (@ProductID, @Category, @ProductName, @Price, @Stocks, @DateAdded, @ProductImage)";
                                SqlCommand insertCommand = new SqlCommand(insertQuery, connect, transaction);
                                insertCommand.Parameters.AddWithValue("@ProductID", dataRow["ProductID"]);
                                insertCommand.Parameters.AddWithValue("@Category", dataRow["Category"]);
                                insertCommand.Parameters.AddWithValue("@ProductName", dataRow["ProductName"]);
                                insertCommand.Parameters.AddWithValue("@Price", dataRow["Price"]);
                                insertCommand.Parameters.AddWithValue("@Stocks", dataRow["Stocks"]);
                                insertCommand.Parameters.AddWithValue("@DateAdded", DateTime.Now);
                                insertCommand.Parameters.AddWithValue("@ProductImage", dataRow["ProductImage"] ?? DBNull.Value);
                                insertCommand.ExecuteNonQuery();
                            }

                            string historyQuery = "INSERT INTO ProductHistory (ProductID, Action, Timestamp, Details) VALUES (@ProductID, @Action, @Timestamp, @Details)";
                            SqlCommand historyCommand = new SqlCommand(historyQuery, connect, transaction);
                            historyCommand.Parameters.AddWithValue("@ProductID", dataRow["ProductID"]);
                            historyCommand.Parameters.AddWithValue("@Action", "Removed from Inventory");
                            historyCommand.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                            historyCommand.Parameters.AddWithValue("@Details", $"Product {dataRow["ProductName"]} removed from inventory and sent back to manage product.");
                            historyCommand.ExecuteNonQuery();
                        }

                        using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM InventoryProducts WHERE ProductID = @ProductID", connect, transaction))
                        {
                            foreach (int productID in productIDsToRemove)
                            {
                                deleteCommand.Parameters.Clear();
                                deleteCommand.Parameters.AddWithValue("@ProductID", productID);
                                deleteCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        RemoveProductsFromInventoryView(productIDsToRemove);
                        LoadInventory();

                        ManageProduct manageProduct = new ManageProduct();
                        manageProduct.LoadProducts();
                        MessageBox.Show($"Product(s) sent back to manage product successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
