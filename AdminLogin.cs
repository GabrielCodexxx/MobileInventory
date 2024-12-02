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
    public partial class AdminLogin : Form
    {
        private SqlConnection connect;

        public AdminLogin()
        {
            InitializeComponent();
            connect = new SqlConnection(@"Data Source=(localdb)\MobileMart;Initial Catalog=MobileMart;Integrated Security=True");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validate that both fields are filled
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Check database connection
            if (CheckConnection())
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT COUNT(*) FROM AdminAccount WHERE txtUsername = @Username AND txtPassword = @Password";

                    using (SqlCommand command = new SqlCommand(selectData, connect))
                    {
                        command.Parameters.AddWithValue("@Username", txtUserName.Text);
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count == 1)
                        {
                            MessageBox.Show("Welcome Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            MainPage mainPage = new MainPage();
                            mainPage.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private bool CheckConnection()
        {
            try
            {
                connect.Open();
                connect.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Database connection failed. Please check your connection settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !cbShowPass.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStoreWalkIn_Click(object sender, EventArgs e)
        {
            WalkInStore walkInStore = new WalkInStore();
            walkInStore.Show();
            this.Hide();
        }
    }
}