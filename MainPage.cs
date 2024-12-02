using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileInventory
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            Dashboard dashboard = new Dashboard();
            dashboard.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(dashboard);
        }

        private void btnMP_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            ManageProduct manageProduct = new ManageProduct();
            manageProduct.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(manageProduct);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            Inventory inventory = new Inventory();
            inventory.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(inventory);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            History history = new History();
            history.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(history);
        }

        private void btnRecycleBin_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            RecycleBinPage recycleBinPage = new RecycleBinPage();
            recycleBinPage.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(recycleBinPage);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }
    }
}
