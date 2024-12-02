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
    public partial class Dashboard : UserControl
    {
        private SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MobileMart;Initial Catalog=MobileMart;Integrated Security=True");

        public Dashboard()
        {
            InitializeComponent();
            LoadNewlyAddedProducts(); // Load newly added products
        }
        private void LoadNewlyAddedProducts()
        {
            try
            {
                // Open the database connection
                connect.Open();

                // Query to fetch newly added products ordered by the latest date
                string query = @"
                SELECT 
                ProductName AS [Product Name], Category, FORMAT(Price, 'C', 'en-PH') AS [Price] FROM InventoryProducts ORDER BY DateAdded DESC";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    // Use SqlDataAdapter to fill a DataTable with the query results
                    System.Data.DataTable dt = new System.Data.DataTable();  // Explicitly specify System.Data.DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    // Bind the DataTable to the DataGridView
                    dataGridViewNewlyAddedProd.DataSource = dt;

                    // Optional: Configure column widths, styles, etc.
                    dataGridViewNewlyAddedProd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                // Display an error toast notification
                MessageBox.Show($"Error loading newly added products:{Environment.NewLine}{ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the database connection is closed
                connect.Close();
            }
        }

        private void LoadLowStockNotifications()
        {
            int lowStockLevel = 5;

            try
            {
                // Open the database connection
                connect.Open();

                // Query to fetch low-stock notifications
                string query = @"
                SELECT 
                    ProductName AS [Product Name], 
                    CASE 
                        WHEN Stocks = 0 THEN 'Out of Stock, Need to Restock' 
                        ELSE CONCAT('Low Stock: ', Stocks, ' units') 
                    END AS [Status]
                FROM InventoryProducts 
                WHERE Stocks <= @LowStockLevel";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    // Add the parameter for low stock level
                    cmd.Parameters.AddWithValue("@LowStockLevel", lowStockLevel);

                    // Use SqlDataAdapter to fill a DataTable with the query results
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();  // Explicitly specify System.Data.DataTable
                    adapter.Fill(dt);

                    // Bind the DataTable to the DataGridView
                    dataGridViewNotif.DataSource = dt;

                    // Optional: Configure column widths, styles, etc.
                    dataGridViewNotif.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                // Display an error toast notification
                MessageBox.Show($"Error loading low stock notifications:{Environment.NewLine}{ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                // Ensure the database connection is closed
                connect.Close();
            }
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            LoadLowStockNotifications();

        }
    }
}
