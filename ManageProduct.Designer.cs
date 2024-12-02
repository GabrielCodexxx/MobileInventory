namespace MobileInventory
{
    partial class ManageProduct
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
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.btnSendToInventory = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ProductViewGrid = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStocks = new System.Windows.Forms.TextBox();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.productImageBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearFields = new System.Windows.Forms.Button();
            this.btnAddProcduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductViewGrid)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productImageBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(18, 185);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(279, 35);
            this.txtPrice.TabIndex = 9;
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(18, 117);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(279, 35);
            this.txtProductName.TabIndex = 8;
            // 
            // cbCategory
            // 
            this.cbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "IPHONE",
            "SAMSUNG",
            "VIVO",
            "HUAWEI",
            "ROG"});
            this.cbCategory.Location = new System.Drawing.Point(18, 47);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(279, 37);
            this.cbCategory.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stock:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phone name:";
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
            this.cbCategoryFilter.Location = new System.Drawing.Point(486, 16);
            this.cbCategoryFilter.Name = "cbCategoryFilter";
            this.cbCategoryFilter.Size = new System.Drawing.Size(193, 28);
            this.cbCategoryFilter.TabIndex = 15;
            this.cbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cbCategoryFilter_SelectedIndexChanged);
            // 
            // btnSendToInventory
            // 
            this.btnSendToInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(195)))), ((int)(((byte)(173)))));
            this.btnSendToInventory.ForeColor = System.Drawing.Color.Black;
            this.btnSendToInventory.Location = new System.Drawing.Point(738, 10);
            this.btnSendToInventory.Name = "btnSendToInventory";
            this.btnSendToInventory.Size = new System.Drawing.Size(203, 38);
            this.btnSendToInventory.TabIndex = 14;
            this.btnSendToInventory.Text = "SEND TO INVENTORY";
            this.btnSendToInventory.UseVisualStyleBackColor = false;
            this.btnSendToInventory.Click += new System.EventHandler(this.btnSendToInventory_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MobileInventory.Properties.Resources.search__1_;
            this.pictureBox1.Location = new System.Drawing.Point(6, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // ProductViewGrid
            // 
            this.ProductViewGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.ProductViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductViewGrid.Location = new System.Drawing.Point(5, 52);
            this.ProductViewGrid.Name = "ProductViewGrid";
            this.ProductViewGrid.RowHeadersWidth = 62;
            this.ProductViewGrid.RowTemplate.Height = 28;
            this.ProductViewGrid.Size = new System.Drawing.Size(936, 876);
            this.ProductViewGrid.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(18, 323);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(282, 35);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Date:";
            // 
            // txtStocks
            // 
            this.txtStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStocks.Location = new System.Drawing.Point(18, 253);
            this.txtStocks.Name = "txtStocks";
            this.txtStocks.Size = new System.Drawing.Size(279, 35);
            this.txtStocks.TabIndex = 10;
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBar.Location = new System.Drawing.Point(50, 16);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(429, 30);
            this.txtSearchBar.TabIndex = 11;
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(195)))), ((int)(((byte)(173)))));
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.Location = new System.Drawing.Point(57, 575);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(194, 44);
            this.btnUpload.TabIndex = 14;
            this.btnUpload.Text = "Upload Image";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(163)))), ((int)(((byte)(176)))));
            this.panel3.Controls.Add(this.btnUpload);
            this.panel3.Controls.Add(this.productImageBox);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtStocks);
            this.panel3.Controls.Add(this.txtPrice);
            this.panel3.Controls.Add(this.txtProductName);
            this.panel3.Controls.Add(this.cbCategory);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(9, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(319, 642);
            this.panel3.TabIndex = 7;
            // 
            // productImageBox
            // 
            this.productImageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(45)))));
            this.productImageBox.Location = new System.Drawing.Point(18, 378);
            this.productImageBox.Name = "productImageBox";
            this.productImageBox.Size = new System.Drawing.Size(282, 177);
            this.productImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.productImageBox.TabIndex = 13;
            this.productImageBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Category:";
            // 
            // btnClearFields
            // 
            this.btnClearFields.BackColor = System.Drawing.Color.White;
            this.btnClearFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFields.ForeColor = System.Drawing.Color.Black;
            this.btnClearFields.Location = new System.Drawing.Point(42, 216);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(227, 59);
            this.btnClearFields.TabIndex = 3;
            this.btnClearFields.Text = "CLEAR";
            this.btnClearFields.UseVisualStyleBackColor = false;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // btnAddProcduct
            // 
            this.btnAddProcduct.BackColor = System.Drawing.Color.White;
            this.btnAddProcduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProcduct.ForeColor = System.Drawing.Color.Black;
            this.btnAddProcduct.Location = new System.Drawing.Point(42, 21);
            this.btnAddProcduct.Name = "btnAddProcduct";
            this.btnAddProcduct.Size = new System.Drawing.Size(227, 59);
            this.btnAddProcduct.TabIndex = 0;
            this.btnAddProcduct.Text = "ADD";
            this.btnAddProcduct.UseVisualStyleBackColor = false;
            this.btnAddProcduct.Click += new System.EventHandler(this.btnAddProcduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.BackColor = System.Drawing.Color.White;
            this.btnUpdateProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProduct.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateProduct.Location = new System.Drawing.Point(42, 86);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(227, 59);
            this.btnUpdateProduct.TabIndex = 1;
            this.btnUpdateProduct.Text = "UPDATE";
            this.btnUpdateProduct.UseVisualStyleBackColor = false;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.BackColor = System.Drawing.Color.White;
            this.btnRemoveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveProduct.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveProduct.Location = new System.Drawing.Point(42, 151);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(227, 59);
            this.btnRemoveProduct.TabIndex = 2;
            this.btnRemoveProduct.Text = "REMOVE";
            this.btnRemoveProduct.UseVisualStyleBackColor = false;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(163)))), ((int)(((byte)(176)))));
            this.panel1.Controls.Add(this.btnClearFields);
            this.panel1.Controls.Add(this.btnAddProcduct);
            this.panel1.Controls.Add(this.btnUpdateProduct);
            this.panel1.Controls.Add(this.btnRemoveProduct);
            this.panel1.Location = new System.Drawing.Point(9, 651);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 289);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(163)))), ((int)(((byte)(176)))));
            this.panel2.Controls.Add(this.cbCategoryFilter);
            this.panel2.Controls.Add(this.btnSendToInventory);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.ProductViewGrid);
            this.panel2.Controls.Add(this.txtSearchBar);
            this.panel2.Location = new System.Drawing.Point(334, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(944, 931);
            this.panel2.TabIndex = 6;
            // 
            // ManageProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "ManageProduct";
            this.Size = new System.Drawing.Size(1286, 949);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductViewGrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productImageBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCategoryFilter;
        private System.Windows.Forms.Button btnSendToInventory;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView ProductViewGrid;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStocks;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox productImageBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearFields;
        private System.Windows.Forms.Button btnAddProcduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
