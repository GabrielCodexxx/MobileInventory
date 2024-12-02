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

namespace MobileInventory
{
    public partial class WalkInStore : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MobileMart;Initial Catalog=MobileMart;Integrated Security=True");
        private Panel overlayPanel; 
        public WalkInStore()
        {
            InitializeComponent();
            LoadInventory();
            LoadRequestData();
            // Initialize the overlay panel
            overlayPanel = new Panel
            {
                Size = new Size(300, 300), // Size of the overlay panel
                BackColor = Color.White, // Background color for contrast (optional)
                Location = new Point((this.Width - 300) / 2, (this.Height - 300) / 2), // Center it
                Visible = false // Start off hidden
            };
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront(); // Ensure it's above other controls

            ProductViewGridCaloocanInventory.CellMouseEnter += ProductViewGridCaloocanInventory_CellMouseEnter;
            ProductViewGridCaloocanInventory.CellMouseLeave += ProductViewGridCaloocanInventory_CellMouseLeave;
            ProductViewGridCaloocanInventory.CellDoubleClick += ProductViewGridCaloocanInventory_CellDoubleClick; // Handle double-click event
            ProductViewGridCaloocanInventoryRequestOrder.CellDoubleClick += ProductViewGridCaloocanInventoryRequestOrder_CellDoubleClick;
        }

        private void ProductViewGridCaloocanInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = ProductViewGridCaloocanInventory.Rows[e.RowIndex];

                    string productId = selectedRow.Cells["ProductID"].Value?.ToString();
                    string productName = selectedRow.Cells["ProductName"].Value?.ToString();
                    decimal price = selectedRow.Cells["Price"].Value != DBNull.Value ? Convert.ToDecimal(selectedRow.Cells["Price"].Value) : 0;
                    int stockIncrement = 1; 

                    if (string.IsNullOrEmpty(productId) || string.IsNullOrEmpty(productName))
                    {
                        MessageBox.Show("Product data is incomplete. Please check the product details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string checkQuery = "SELECT Stocks FROM Cart WHERE ProductID = @ProductID";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connect))
                    {
                        checkCommand.Parameters.AddWithValue("@ProductID", productId);

                        connect.Open();
                        object result = checkCommand.ExecuteScalar();
                        connect.Close();

                        if (result != null)
                        {
                            int currentStock = Convert.ToInt32(result);

                            string updateCartQuery = @"
                        UPDATE Cart 
                        SET Stocks = Stocks + @StockIncrement, 
                            Price = Price + @PriceIncrement 
                        WHERE ProductID = @ProductID";

                            using (SqlCommand updateCommand = new SqlCommand(updateCartQuery, connect))
                            {
                                connect.Open();
                                updateCommand.Parameters.AddWithValue("@ProductID", productId);
                                updateCommand.Parameters.AddWithValue("@StockIncrement", stockIncrement);
                                updateCommand.Parameters.AddWithValue("@PriceIncrement", price);
                                updateCommand.ExecuteNonQuery();
                                connect.Close();
                            }

                            string updateInventoryQuery = @"
                        UPDATE InventoryProducts
                        SET Stocks = Stocks - @StockDecrement
                        WHERE ProductID = @ProductID";

                            using (SqlCommand updateInventoryCommand = new SqlCommand(updateInventoryQuery, connect))
                            {
                                connect.Open();
                                updateInventoryCommand.Parameters.AddWithValue("@ProductID", productId);
                                updateInventoryCommand.Parameters.AddWithValue("@StockDecrement", stockIncrement);
                                updateInventoryCommand.ExecuteNonQuery();
                                connect.Close();
                            }

                            MessageBox.Show("Product stock updated in the Cart and Inventory.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string category = selectedRow.Cells["Category"].Value?.ToString();
                            int stocks = selectedRow.Cells["Stocks"].Value != DBNull.Value ? Convert.ToInt32(selectedRow.Cells["Stocks"].Value) : 0;
                            DateTime dateAdded = selectedRow.Cells["DateAdded"].Value != DBNull.Value ? Convert.ToDateTime(selectedRow.Cells["DateAdded"].Value) : DateTime.Now;
                            string productImage = selectedRow.Cells["ProductImage"].Value?.ToString();

                            string insertQuery = @"
                        INSERT INTO Cart (ProductID, Category, ProductName, Price, Stocks, DateAdded, ProductImage)
                        VALUES (@ProductID, @Category, @ProductName, @Price, @Stocks, @DateAdded, @ProductImage)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connect))
                            {
                                connect.Open();
                                insertCommand.Parameters.AddWithValue("@ProductID", productId);
                                insertCommand.Parameters.AddWithValue("@Category", category);
                                insertCommand.Parameters.AddWithValue("@ProductName", productName);
                                insertCommand.Parameters.AddWithValue("@Price", price);
                                insertCommand.Parameters.AddWithValue("@Stocks", stockIncrement);
                                insertCommand.Parameters.AddWithValue("@DateAdded", dateAdded);
                                insertCommand.Parameters.AddWithValue("@ProductImage", productImage);
                                insertCommand.ExecuteNonQuery();
                                connect.Close();
                            }

                            string updateInventoryQuery = @"
                        UPDATE InventoryProducts
                        SET Stocks = Stocks - @StockDecrement
                        WHERE ProductID = @ProductID";

                            using (SqlCommand updateInventoryCommand = new SqlCommand(updateInventoryQuery, connect))
                            {
                                connect.Open();
                                updateInventoryCommand.Parameters.AddWithValue("@ProductID", productId);
                                updateInventoryCommand.Parameters.AddWithValue("@StockDecrement", stockIncrement);
                                updateInventoryCommand.ExecuteNonQuery();
                                connect.Close();
                            }

                            MessageBox.Show("Product added to Cart and Inventory stock updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    LoadRequestData(); 
                    LoadInventory();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error processing product:{Environment.NewLine}{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void ProductViewGridCaloocanInventoryRequestOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = ProductViewGridCaloocanInventoryRequestOrder.Rows[e.RowIndex];

                    string productId = selectedRow.Cells["ProductID"].Value?.ToString();
                    int currentStockInCart = Convert.ToInt32(selectedRow.Cells["Stocks"].Value); // Assuming the "Stocks" column contains stock info in the Cart
                    decimal productPrice = Convert.ToDecimal(selectedRow.Cells["Price"].Value); // Assuming the "Price" column contains the price in the Cart

                    if (currentStockInCart > 1)
                    {
                        string updateCartQuery = @"
                    UPDATE Cart 
                    SET Stocks = Stocks - @StockDecrement, 
                        Price = Price - @PriceDecrement
                    WHERE ProductID = @ProductID";

                        using (SqlCommand updateCartCommand = new SqlCommand(updateCartQuery, connect))
                        {
                            connect.Open();
                            updateCartCommand.Parameters.AddWithValue("@StockDecrement", 1);  
                            updateCartCommand.Parameters.AddWithValue("@PriceDecrement", productPrice / currentStockInCart);  
                            updateCartCommand.Parameters.AddWithValue("@ProductID", productId);
                            updateCartCommand.ExecuteNonQuery();
                            connect.Close();
                        }

                        string updateInventoryQuery = @"
                    UPDATE InventoryProducts 
                    SET Stocks = Stocks + @StockIncrement
                    WHERE ProductID = @ProductID";

                        using (SqlCommand updateInventoryCommand = new SqlCommand(updateInventoryQuery, connect))
                        {
                            connect.Open();
                            updateInventoryCommand.Parameters.AddWithValue("@StockIncrement", 1);  
                            updateInventoryCommand.Parameters.AddWithValue("@ProductID", productId);
                            updateInventoryCommand.ExecuteNonQuery();
                            connect.Close();
                        }

                        MessageBox.Show("Product stock updated and inventory restocked.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string deleteFromCartQuery = @"
                    DELETE FROM Cart 
                    WHERE ProductID = @ProductID";

                        using (SqlCommand deleteFromCartCommand = new SqlCommand(deleteFromCartQuery, connect))
                        {
                            connect.Open();
                            deleteFromCartCommand.Parameters.AddWithValue("@ProductID", productId);
                            deleteFromCartCommand.ExecuteNonQuery();
                            connect.Close();
                        }

                        string updateInventoryQuery = @"
                    UPDATE InventoryProducts 
                    SET Stocks = Stocks + @StockIncrement
                    WHERE ProductID = @ProductID";

                        using (SqlCommand updateInventoryCommand = new SqlCommand(updateInventoryQuery, connect))
                        {
                            connect.Open();
                            updateInventoryCommand.Parameters.AddWithValue("@StockIncrement", 1); 
                            updateInventoryCommand.Parameters.AddWithValue("@ProductID", productId);
                            updateInventoryCommand.ExecuteNonQuery();
                            connect.Close();
                        }

                        MessageBox.Show("Product removed from cart and inventory updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadInventory();
                    LoadRequestData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error processing product:{Environment.NewLine}{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
        }
        private void ProductViewGridCaloocanInventory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && ProductViewGridCaloocanInventory.Columns[e.ColumnIndex].Name == "ProductImage" && e.RowIndex >= 0)
            {
                string imagePath = ProductViewGridCaloocanInventory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    overlayPanel.BackgroundImage = Image.FromFile(imagePath);
                    overlayPanel.BackgroundImageLayout = ImageLayout.Zoom; 
                    overlayPanel.Visible = true; 
                }
            }
        }

        private void ProductViewGridCaloocanInventory_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            overlayPanel.Visible = false;
        }
        public void LoadRequestData()
        {
            try
            {
                string query = "SELECT ProductID, ProductName, Stocks, Price FROM Cart";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ProductViewGridCaloocanInventoryRequestOrder.DataSource = dt;
                ProductViewGridCaloocanInventoryRequestOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ProductViewGridCaloocanInventoryRequestOrder.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                ProductViewGridCaloocanInventoryRequestOrder.Columns["ProductID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}");
            }
        }
        public void LoadInventory()
        {
            try
            {
                string query = "SELECT * FROM InventoryProducts";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ProductViewGridCaloocanInventory.DataSource = dt;
                ProductViewGridCaloocanInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ProductViewGridCaloocanInventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}");
            }
        }
        private void WalkInStore_Load(object sender, EventArgs e)
        {

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

                    ProductViewGridCaloocanInventory.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    ProductViewGridCaloocanInventory.DataSource = dt;
                    ProductViewGridCaloocanInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    ProductViewGridCaloocanInventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }
    }
}
