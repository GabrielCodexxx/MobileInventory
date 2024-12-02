using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MobileInventory
{
    public partial class ManageProduct : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MobileMart;Initial Catalog=MobileMart;Integrated Security=True");
        private string productImagePath;
        private Panel overlayPanel; 
        public ManageProduct()
        {
            InitializeComponent();
            LoadProducts();
            ProductViewGrid.CellClick += new DataGridViewCellEventHandler(ProductViewGrid_CellClick);
            ProductViewGrid.CellMouseEnter += ProductViewGrid_CellMouseEnter;
            ProductViewGrid.CellMouseLeave += ProductViewGrid_CellMouseLeave;
            overlayPanel = new Panel
            {
                Size = new Size(300, 300), 
                BackColor = Color.White, 
                Location = new Point((this.Width - 300) / 2, (this.Height - 300) / 2), 
                Visible = false 
            };
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront(); 
        }

        private void ProductViewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ProductViewGrid.Rows[e.RowIndex];

                try
                {
                    txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                    cbCategory.Text = row.Cells["Category"].Value.ToString();
                    txtPrice.Text = row.Cells["Price"].Value.ToString();
                    txtStocks.Text = row.Cells["Stocks"].Value.ToString();

                    if (row.Cells["ProductImage"].Value != DBNull.Value && row.Cells["ProductImage"].Value != null)
                    {
                        string imagePath = row.Cells["ProductImage"].Value.ToString();

                        if (File.Exists(imagePath))
                        {
                            productImageBox.Image = Image.FromFile(imagePath);
                        }
                        else
                        {
                            productImageBox.Image = null;
                            MessageBox.Show("Product image file not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    else
                    {
                        productImageBox.Image = null; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void ProductViewGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && ProductViewGrid.Columns[e.ColumnIndex].Name == "ProductImage" && e.RowIndex >= 0)
            {
                string imagePath = ProductViewGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    overlayPanel.BackgroundImage = Image.FromFile(imagePath);
                    overlayPanel.BackgroundImageLayout = ImageLayout.Zoom; 
                    overlayPanel.Visible = true; 
                }
            }
        }

        private void ProductViewGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            overlayPanel.Visible = false;
        }

        public void LoadProducts()
        {
            try
            {
                ProductViewGrid.AutoGenerateColumns = true;

                string query = "SELECT * FROM Products";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                ProductViewGrid.DataSource = dt;

                ProductViewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ProductViewGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBar.Text.Trim();
                string selectedCategory = cbCategoryFilter.SelectedIndex > -1 ? cbCategoryFilter.SelectedItem.ToString() : null;

                if (string.IsNullOrEmpty(searchText))
                {
                    if (string.IsNullOrEmpty(selectedCategory) || selectedCategory == "All")
                    {
                        LoadProducts(); 
                        return;
                    }
                    else
                    {
                        FilterProductsByCategory(selectedCategory);
                        return;
                    }
                }

                string query = @"SELECT ProductID, Category, ProductName, Price, Stocks, DateAdded, ProductImage FROM Products 
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

                    ProductViewGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void FilterProductsByCategory(string category)
        {
            try
            {
                string query = "SELECT ProductID, Category, ProductName, Price, Stocks, DateAdded, ProductImage FROM Products WHERE Category = @Category";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@Category", category);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    ProductViewGrid.DataSource = dt;
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
                LoadProducts();
            }
            else
            {
                FilterProductsByCategory(selectedCategory);
            }
        }

        private void btnSendToInventory_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductViewGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a product to send to inventory.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                List<int> productIDsToRemove = new List<int>();
                DataTable inventoryData = new DataTable();
                inventoryData.Columns.Add("ProductID");
                inventoryData.Columns.Add("Category");
                inventoryData.Columns.Add("ProductName");
                inventoryData.Columns.Add("Price");
                inventoryData.Columns.Add("Stocks");
                inventoryData.Columns.Add("DateAdded");
                inventoryData.Columns.Add("ProductImage");

                foreach (DataGridViewRow row in ProductViewGrid.SelectedRows)
                {
                    if (row.Cells["ProductID"].Value != null)
                    {
                        inventoryData.Rows.Add(
                            row.Cells["ProductID"].Value,
                            row.Cells["Category"].Value,
                            row.Cells["ProductName"].Value,
                            row.Cells["Price"].Value,
                            row.Cells["Stocks"].Value,
                            DateTime.Now,
                            row.Cells["ProductImage"].Value
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
                        foreach (DataRow dataRow in inventoryData.Rows)
                        {
                            string checkQuery = "SELECT Stocks FROM InventoryProducts WHERE ProductName = @ProductName";
                            SqlCommand checkCommand = new SqlCommand(checkQuery, connect, transaction);
                            checkCommand.Parameters.AddWithValue("@ProductName", dataRow["ProductName"]);

                            object result = checkCommand.ExecuteScalar();

                            if (result != null) 
                            {
                                int existingStocks = Convert.ToInt32(result);
                                string updateQuery = "UPDATE InventoryProducts SET Stocks = @Stocks WHERE ProductName = @ProductName";
                                SqlCommand updateCommand = new SqlCommand(updateQuery, connect, transaction);
                                updateCommand.Parameters.AddWithValue("@Stocks", existingStocks + Convert.ToInt32(dataRow["Stocks"]));
                                updateCommand.Parameters.AddWithValue("@ProductName", dataRow["ProductName"]);
                                updateCommand.ExecuteNonQuery();
                            }
                            else 
                            {
                                string insertQuery = "INSERT INTO InventoryProducts (ProductID, Category, ProductName, Price, Stocks, DateAdded, ProductImage) " +
                                                     "VALUES (@ProductID, @Category, @ProductName, @Price, @Stocks, @DateAdded, @ProductImage)";
                                SqlCommand insertCommand = new SqlCommand(insertQuery, connect, transaction);
                                insertCommand.Parameters.AddWithValue("@ProductID", dataRow["ProductID"]);
                                insertCommand.Parameters.AddWithValue("@Category", dataRow["Category"]);
                                insertCommand.Parameters.AddWithValue("@ProductName", dataRow["ProductName"]);
                                insertCommand.Parameters.AddWithValue("@Price", dataRow["Price"]);
                                insertCommand.Parameters.AddWithValue("@Stocks", dataRow["Stocks"]);
                                insertCommand.Parameters.AddWithValue("@DateAdded", DateTime.Now);
                                insertCommand.Parameters.AddWithValue("@ProductImage", dataRow["ProductImage"]);

                                insertCommand.ExecuteNonQuery();
                            }

                            
                            string historyQuery = "INSERT INTO ProductHistory (ProductID, Action, Timestamp, Details) " +
                                                  "VALUES (@ProductID, @Action, @Timestamp, @Details)";
                            SqlCommand historyCommand = new SqlCommand(historyQuery, connect, transaction);
                            historyCommand.Parameters.AddWithValue("@ProductID", dataRow["ProductID"]);
                            historyCommand.Parameters.AddWithValue("@Action", "Added to Inventory");
                            historyCommand.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                            historyCommand.Parameters.AddWithValue("@Details", $"Product {dataRow["ProductName"]} added to inventory.");
                            historyCommand.ExecuteNonQuery();
                        }

                        
                        using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM Products WHERE ProductID = @ProductID", connect, transaction))
                        {
                            foreach (int productID in productIDsToRemove)
                            {
                                deleteCommand.Parameters.Clear();
                                deleteCommand.Parameters.AddWithValue("@ProductID", productID);
                                deleteCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        RemoveProductsFromManageView(productIDsToRemove);
                        LoadProducts();

                        Inventory inventory = new Inventory();
                        inventory.LoadInventory();

                        MessageBox.Show("Product(s) sent to inventory successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        private void RemoveProductsFromManageView(List<int> productIDs)
        {
            try
            {
                foreach (int productID in productIDs)
                {
                    foreach (DataGridViewRow row in ProductViewGrid.Rows)
                    {
                        if (row.Cells["ProductID"].Value != null &&
                            row.Cells["ProductID"].Value is int id &&
                            id == productID)
                        {
                            ProductViewGrid.Rows.Remove(row);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing products from view: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddProcduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProductName.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtStocks.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text.Replace("₱", "").Trim(), out decimal price) || price <= 0)
                {
                    MessageBox.Show("Please enter a valid numeric value for the price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrice.Focus();
                    return;
                }

                if (!int.TryParse(txtStocks.Text, out int stocks) || stocks < 0)
                {
                    MessageBox.Show("Please enter a valid numeric value for the stock quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStocks.Focus();
                    return;
                }

                string checkQuery = "SELECT ProductID, Stocks FROM Products WHERE ProductName = @ProductName";
                int existingProductID = 0;
                int existingStocks = 0;

                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connect))
                {
                    checkCommand.Parameters.AddWithValue("@ProductName", txtProductName.Text);

                    connect.Open();
                    using (SqlDataReader reader = checkCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            existingProductID = reader.GetInt32(0);
                            existingStocks = reader.GetInt32(1);
                        }
                    }
                    connect.Close();
                }

                if (existingProductID > 0)
                {
                    string updateQuery = "UPDATE Products SET Stocks = @Stocks WHERE ProductID = @ProductID";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connect))
                    {
                        updateCommand.Parameters.AddWithValue("@Stocks", existingStocks + stocks);
                        updateCommand.Parameters.AddWithValue("@ProductID", existingProductID);

                        connect.Open();
                        updateCommand.ExecuteNonQuery();
                        connect.Close();
                    }

                    MessageBox.Show("Product stock updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    Random random = new Random();
                    int productID;
                    bool isUnique;

                    do
                    {
                        productID = random.Next(100, 1000);
                        string idQuery = "SELECT COUNT(*) FROM Products WHERE ProductID = @ProductID";
                        using (SqlCommand idCommand = new SqlCommand(idQuery, connect))
                        {
                            idCommand.Parameters.AddWithValue("@ProductID", productID);

                            connect.Open();
                            isUnique = (int)idCommand.ExecuteScalar() == 0;
                            connect.Close();
                        }

                    } while (!isUnique);

                    // Insert new product
                    string insertQuery = "INSERT INTO Products (ProductID, Category, ProductName, Price, Stocks, DateAdded, ProductImage) " +
                                         "VALUES (@ProductID, @Category, @ProductName, @Price, @Stocks, @DateAdded, @ProductImage)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connect))
                    {
                        insertCommand.Parameters.AddWithValue("@ProductID", productID);
                        insertCommand.Parameters.AddWithValue("@Category", cbCategory.Text);
                        insertCommand.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        insertCommand.Parameters.AddWithValue("@Price", price);
                        insertCommand.Parameters.AddWithValue("@Stocks", stocks);
                        insertCommand.Parameters.AddWithValue("@DateAdded", dateTimePicker1.Value);

                        insertCommand.Parameters.AddWithValue("@ProductImage", string.IsNullOrEmpty(productImagePath) ? (object)DBNull.Value : productImagePath);

                        connect.Open();
                        insertCommand.ExecuteNonQuery();
                        connect.Close();
                    }

                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductViewGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a product to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtProductName.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtStocks.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Please enter a valid numeric value for the price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrice.Focus();
                    return;
                }

                if (!int.TryParse(txtStocks.Text, out int stocks) || stocks < 0)
                {
                    MessageBox.Show("Please enter a valid numeric value for the stock quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStocks.Focus();
                    return;
                }

                int productID = (int)ProductViewGrid.SelectedRows[0].Cells["ProductID"].Value;

                string query = "UPDATE Products SET Category = @Category, ProductName = @ProductName, Price = @Price, Stocks = @Stocks, DateAdded = @DateAdded";

                if (!string.IsNullOrEmpty(productImagePath))
                {
                    query += ", ProductImage = @ProductImage";
                }

                query += " WHERE ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@ProductID", productID);
                    command.Parameters.AddWithValue("@Category", cbCategory.Text);
                    command.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Stocks", stocks);
                    command.Parameters.AddWithValue("@DateAdded", dateTimePicker1.Value);

                    if (!string.IsNullOrEmpty(productImagePath))
                    {
                        command.Parameters.AddWithValue("@ProductImage", productImagePath);
                    }

                    connect.Open();
                    command.ExecuteNonQuery();
                    connect.Close();
                }

                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductViewGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select one or more products to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                connect.Open();
                SqlTransaction transaction = connect.BeginTransaction();

                try
                {
                    foreach (DataGridViewRow selectedRow in ProductViewGrid.SelectedRows)
                    {
                        if (selectedRow.Cells["ProductID"].Value == null || selectedRow.Cells["ProductID"].Value == DBNull.Value)
                        {
                            continue;
                        }

                        string productName = selectedRow.Cells["ProductName"].Value.ToString();
                        int removeStocks = Convert.ToInt32(selectedRow.Cells["Stocks"].Value);

                        string checkQuery = "SELECT Stocks FROM Products WHERE ProductName = @ProductName";
                        SqlCommand checkCommand = new SqlCommand(checkQuery, connect, transaction);
                        checkCommand.Parameters.AddWithValue("@ProductName", productName);

                        object result = checkCommand.ExecuteScalar();

                        if (result != null) 
                        {
                            int existingStocks = Convert.ToInt32(result);
                            int updatedStocks = existingStocks - removeStocks;

                            if (updatedStocks > 0)
                            {
                                string updateQuery = "UPDATE Products SET Stocks = @Stocks WHERE ProductName = @ProductName";
                                SqlCommand updateCommand = new SqlCommand(updateQuery, connect, transaction);
                                updateCommand.Parameters.AddWithValue("@Stocks", updatedStocks);
                                updateCommand.Parameters.AddWithValue("@ProductName", productName);
                                updateCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                string category = selectedRow.Cells["Category"].Value.ToString();
                                decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
                                string productImage = selectedRow.Cells["ProductImage"].Value.ToString();
                                DateTime dateAdded = DateTime.Now;

                                string insertQuery = "INSERT INTO RecycleBinProducts (ProductID, Category, ProductName, Price, Stocks, DateAdded, ProductImage) " +
                                                     "VALUES (@ProductID, @Category, @ProductName, @Price, @Stocks, @DateAdded, @ProductImage)";
                                SqlCommand insertCommand = new SqlCommand(insertQuery, connect, transaction);
                                insertCommand.Parameters.AddWithValue("@ProductID", selectedRow.Cells["ProductID"].Value);
                                insertCommand.Parameters.AddWithValue("@Category", category);
                                insertCommand.Parameters.AddWithValue("@ProductName", productName);
                                insertCommand.Parameters.AddWithValue("@Price", price);
                                insertCommand.Parameters.AddWithValue("@Stocks", removeStocks);
                                insertCommand.Parameters.AddWithValue("@DateAdded", dateAdded);
                                insertCommand.Parameters.AddWithValue("@ProductImage", productImage);
                                insertCommand.ExecuteNonQuery();

                                string deleteQuery = "DELETE FROM Products WHERE ProductName = @ProductName";
                                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connect, transaction);
                                deleteCommand.Parameters.AddWithValue("@ProductName", productName);
                                deleteCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();

                    MessageBox.Show("Selected products removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadProducts();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            cbCategory.SelectedIndex = -1;
            txtProductName.Clear();
            txtPrice.Clear();
            txtStocks.Clear();
            productImageBox.Image = null;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(openFileDialog.FileName);
                    string destPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TechVault", "Product_Images", fileName);

                    try
                    {
                        File.Copy(openFileDialog.FileName, destPath, true);
                        productImageBox.Image = Image.FromFile(destPath);
                        productImagePath = destPath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
