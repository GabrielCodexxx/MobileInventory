namespace MobileInventory
{
    partial class Inventory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.btnManage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ProductViewGridInventory = new System.Windows.Forms.DataGridView();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductViewGridInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCategoryFilter
            // 
            this.cbCategoryFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoryFilter.FormattingEnabled = true;
            this.cbCategoryFilter.Items.AddRange(new object[] {
            "IPHONE",
            "SAMSUNG",
            "VIVO",
            "HUAWEI",
            "ROG"});
            this.cbCategoryFilter.Location = new System.Drawing.Point(776, 12);
            this.cbCategoryFilter.Name = "cbCategoryFilter";
            this.cbCategoryFilter.Size = new System.Drawing.Size(249, 33);
            this.cbCategoryFilter.TabIndex = 23;
            this.cbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cbCategoryFilter_SelectedIndexChanged);
            // 
            // btnManage
            // 
            this.btnManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(195)))), ((int)(((byte)(173)))));
            this.btnManage.ForeColor = System.Drawing.Color.Black;
            this.btnManage.Location = new System.Drawing.Point(1123, 6);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(160, 50);
            this.btnManage.TabIndex = 22;
            this.btnManage.Text = "MANAGE";
            this.btnManage.UseVisualStyleBackColor = false;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MobileInventory.Properties.Resources.search__1_;
            this.pictureBox1.Location = new System.Drawing.Point(281, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // ProductViewGridInventory
            // 
            this.ProductViewGridInventory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(163)))), ((int)(((byte)(176)))));
            this.ProductViewGridInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductViewGridInventory.Location = new System.Drawing.Point(3, 62);
            this.ProductViewGridInventory.Name = "ProductViewGridInventory";
            this.ProductViewGridInventory.RowHeadersWidth = 62;
            this.ProductViewGridInventory.RowTemplate.Height = 28;
            this.ProductViewGridInventory.Size = new System.Drawing.Size(1280, 881);
            this.ProductViewGridInventory.TabIndex = 20;
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBar.Location = new System.Drawing.Point(341, 14);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(429, 30);
            this.txtSearchBar.TabIndex = 19;
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.Controls.Add(this.cbCategoryFilter);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ProductViewGridInventory);
            this.Controls.Add(this.txtSearchBar);
            this.Name = "Inventory";
            this.Size = new System.Drawing.Size(1286, 949);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductViewGridInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCategoryFilter;
        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView ProductViewGridInventory;
        private System.Windows.Forms.TextBox txtSearchBar;
    }
}
