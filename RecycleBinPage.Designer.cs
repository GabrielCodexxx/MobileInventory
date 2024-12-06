namespace MobileInventory
{
    partial class RecycleBinPage
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.cbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RecycleBinViewGrid = new System.Windows.Forms.DataGridView();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecycleBinViewGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(163)))), ((int)(((byte)(176)))));
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnUndo);
            this.panel2.Controls.Add(this.cbCategoryFilter);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.RecycleBinViewGrid);
            this.panel2.Controls.Add(this.txtSearchBar);
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1266, 929);
            this.panel2.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(195)))), ((int)(((byte)(173)))));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(1119, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(137, 46);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(195)))), ((int)(((byte)(173)))));
            this.btnUndo.ForeColor = System.Drawing.Color.Black;
            this.btnUndo.Location = new System.Drawing.Point(11, 3);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(137, 46);
            this.btnUndo.TabIndex = 20;
            this.btnUndo.Text = "UNDO";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // cbCategoryFilter
            // 
            this.cbCategoryFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoryFilter.FormattingEnabled = true;
            this.cbCategoryFilter.Items.AddRange(new object[] {
            "IPHONE",
            "SAMSUNG",
            "VIVO",
            "HUAWEI",
            "ROG"});
            this.cbCategoryFilter.Location = new System.Drawing.Point(770, 9);
            this.cbCategoryFilter.Name = "cbCategoryFilter";
            this.cbCategoryFilter.Size = new System.Drawing.Size(193, 28);
            this.cbCategoryFilter.TabIndex = 19;
            this.cbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cbCategoryFilter_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MobileInventory.Properties.Resources.search__1_;
            this.pictureBox1.Location = new System.Drawing.Point(290, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // RecycleBinViewGrid
            // 
            this.RecycleBinViewGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.RecycleBinViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecycleBinViewGrid.Location = new System.Drawing.Point(11, 55);
            this.RecycleBinViewGrid.Name = "RecycleBinViewGrid";
            this.RecycleBinViewGrid.RowHeadersWidth = 62;
            this.RecycleBinViewGrid.RowTemplate.Height = 28;
            this.RecycleBinViewGrid.Size = new System.Drawing.Size(1245, 862);
            this.RecycleBinViewGrid.TabIndex = 17;
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBar.Location = new System.Drawing.Point(334, 9);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(429, 30);
            this.txtSearchBar.TabIndex = 16;
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // RecycleBinPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(163)))), ((int)(((byte)(176)))));
            this.Controls.Add(this.panel2);
            this.Name = "RecycleBinPage";
            this.Size = new System.Drawing.Size(1286, 949);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecycleBinViewGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.ComboBox cbCategoryFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView RecycleBinViewGrid;
        private System.Windows.Forms.TextBox txtSearchBar;
    }
}
