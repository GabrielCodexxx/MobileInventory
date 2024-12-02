namespace MobileInventory
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRecycleBin = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnMP = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.dashboard2 = new MobileInventory.Dashboard();
            this.recycleBinPage1 = new MobileInventory.RecycleBinPage();
            this.history1 = new MobileInventory.History();
            this.inventory1 = new MobileInventory.Inventory();
            this.manageProduct1 = new MobileInventory.ManageProduct();
            this.dashboard1 = new MobileInventory.Dashboard();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRecycleBin
            // 
            this.btnRecycleBin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(195)))), ((int)(((byte)(173)))));
            this.btnRecycleBin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecycleBin.Location = new System.Drawing.Point(59, 647);
            this.btnRecycleBin.Name = "btnRecycleBin";
            this.btnRecycleBin.Size = new System.Drawing.Size(238, 47);
            this.btnRecycleBin.TabIndex = 25;
            this.btnRecycleBin.Text = "Recycle Bin";
            this.btnRecycleBin.UseVisualStyleBackColor = false;
            this.btnRecycleBin.Click += new System.EventHandler(this.btnRecycleBin_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(195)))), ((int)(((byte)(173)))));
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Location = new System.Drawing.Point(59, 369);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(238, 47);
            this.btnDashboard.TabIndex = 24;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnMP
            // 
            this.btnMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(195)))), ((int)(((byte)(173)))));
            this.btnMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMP.Location = new System.Drawing.Point(59, 439);
            this.btnMP.Name = "btnMP";
            this.btnMP.Size = new System.Drawing.Size(238, 47);
            this.btnMP.TabIndex = 23;
            this.btnMP.Text = "Manage Product";
            this.btnMP.UseVisualStyleBackColor = false;
            this.btnMP.Click += new System.EventHandler(this.btnMP_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(195)))), ((int)(((byte)(173)))));
            this.btnHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.Location = new System.Drawing.Point(59, 579);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(238, 47);
            this.btnHistory.TabIndex = 22;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(195)))), ((int)(((byte)(173)))));
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.Location = new System.Drawing.Point(59, 508);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(238, 47);
            this.btnInventory.TabIndex = 21;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(195)))), ((int)(((byte)(173)))));
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(59, 827);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(238, 47);
            this.btnLogout.TabIndex = 20;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.MainPanel.Controls.Add(this.dashboard2);
            this.MainPanel.Controls.Add(this.recycleBinPage1);
            this.MainPanel.Controls.Add(this.history1);
            this.MainPanel.Controls.Add(this.inventory1);
            this.MainPanel.Controls.Add(this.manageProduct1);
            this.MainPanel.Controls.Add(this.dashboard1);
            this.MainPanel.Location = new System.Drawing.Point(364, 8);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1286, 949);
            this.MainPanel.TabIndex = 0;
            // 
            // dashboard2
            // 
            this.dashboard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.dashboard2.Location = new System.Drawing.Point(0, 0);
            this.dashboard2.Name = "dashboard2";
            this.dashboard2.Size = new System.Drawing.Size(1286, 949);
            this.dashboard2.TabIndex = 32;
            // 
            // recycleBinPage1
            // 
            this.recycleBinPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(163)))), ((int)(((byte)(176)))));
            this.recycleBinPage1.Location = new System.Drawing.Point(0, 0);
            this.recycleBinPage1.Name = "recycleBinPage1";
            this.recycleBinPage1.Size = new System.Drawing.Size(1286, 949);
            this.recycleBinPage1.TabIndex = 31;
            // 
            // history1
            // 
            this.history1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.history1.Location = new System.Drawing.Point(0, 0);
            this.history1.Name = "history1";
            this.history1.Size = new System.Drawing.Size(1286, 949);
            this.history1.TabIndex = 30;
            // 
            // inventory1
            // 
            this.inventory1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.inventory1.Location = new System.Drawing.Point(0, 0);
            this.inventory1.Name = "inventory1";
            this.inventory1.Size = new System.Drawing.Size(1286, 949);
            this.inventory1.TabIndex = 29;
            // 
            // manageProduct1
            // 
            this.manageProduct1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.manageProduct1.Location = new System.Drawing.Point(0, 0);
            this.manageProduct1.Name = "manageProduct1";
            this.manageProduct1.Size = new System.Drawing.Size(1286, 949);
            this.manageProduct1.TabIndex = 28;
            // 
            // dashboard1
            // 
            this.dashboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.dashboard1.Location = new System.Drawing.Point(3, 0);
            this.dashboard1.Name = "dashboard1";
            this.dashboard1.Size = new System.Drawing.Size(1286, 949);
            this.dashboard1.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MobileInventory.Properties.Resources.c0a160dc_f868_4dc2_a1a5_31e34fd5d40e;
            this.pictureBox1.Location = new System.Drawing.Point(59, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1660, 966);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRecycleBin);
            this.Controls.Add(this.btnDashboard);
            this.Controls.Add(this.btnMP);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPage";
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRecycleBin;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnMP;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Dashboard dashboard1;
        private Dashboard dashboard2;
        private RecycleBinPage recycleBinPage1;
        private History history1;
        private Inventory inventory1;
        private ManageProduct manageProduct1;
    }
}