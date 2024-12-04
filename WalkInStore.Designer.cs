namespace MobileInventory
{
    partial class WalkInStore
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
            this.btnPay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductViewGridCaloocanInventoryRequestOrder = new System.Windows.Forms.DataGridView();
            this.cbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.ProductViewGridCaloocanInventory = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmountToPay = new System.Windows.Forms.TextBox();
            this.txtInputMoney = new System.Windows.Forms.TextBox();
            this.txtChange = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProductViewGridCaloocanInventoryRequestOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductViewGridCaloocanInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(1024, 977);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(177, 45);
            this.btnPay.TabIndex = 47;
            this.btnPay.Text = "PAY";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(895, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 37);
            this.label1.TabIndex = 46;
            this.label1.Text = "Orders";
            // 
            // ProductViewGridCaloocanInventoryRequestOrder
            // 
            this.ProductViewGridCaloocanInventoryRequestOrder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(90)))), ((int)(((byte)(84)))));
            this.ProductViewGridCaloocanInventoryRequestOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductViewGridCaloocanInventoryRequestOrder.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(210)))));
            this.ProductViewGridCaloocanInventoryRequestOrder.Location = new System.Drawing.Point(902, 66);
            this.ProductViewGridCaloocanInventoryRequestOrder.Name = "ProductViewGridCaloocanInventoryRequestOrder";
            this.ProductViewGridCaloocanInventoryRequestOrder.RowHeadersWidth = 62;
            this.ProductViewGridCaloocanInventoryRequestOrder.RowTemplate.Height = 28;
            this.ProductViewGridCaloocanInventoryRequestOrder.Size = new System.Drawing.Size(392, 583);
            this.ProductViewGridCaloocanInventoryRequestOrder.TabIndex = 45;
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
            this.cbCategoryFilter.Location = new System.Drawing.Point(598, 27);
            this.cbCategoryFilter.Name = "cbCategoryFilter";
            this.cbCategoryFilter.Size = new System.Drawing.Size(193, 28);
            this.cbCategoryFilter.TabIndex = 43;
            this.cbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cbCategoryFilter_SelectedIndexChanged);
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBar.Location = new System.Drawing.Point(163, 26);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(429, 30);
            this.txtSearchBar.TabIndex = 41;
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // ProductViewGridCaloocanInventory
            // 
            this.ProductViewGridCaloocanInventory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(90)))), ((int)(((byte)(84)))));
            this.ProductViewGridCaloocanInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductViewGridCaloocanInventory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(210)))));
            this.ProductViewGridCaloocanInventory.Location = new System.Drawing.Point(10, 66);
            this.ProductViewGridCaloocanInventory.Name = "ProductViewGridCaloocanInventory";
            this.ProductViewGridCaloocanInventory.RowHeadersWidth = 62;
            this.ProductViewGridCaloocanInventory.RowTemplate.Height = 28;
            this.ProductViewGridCaloocanInventory.Size = new System.Drawing.Size(882, 960);
            this.ProductViewGridCaloocanInventory.TabIndex = 44;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MobileInventory.Properties.Resources.search__1_;
            this.pictureBox1.Location = new System.Drawing.Point(119, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1243, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 44);
            this.button1.TabIndex = 48;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(903, 699);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 37);
            this.label2.TabIndex = 49;
            this.label2.Text = "AMOUNT TO PAY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(903, 861);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 37);
            this.label3.TabIndex = 50;
            this.label3.Text = "CHANGE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(903, 780);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 37);
            this.label4.TabIndex = 51;
            this.label4.Text = "INPUT MONEY";
            // 
            // txtAmountToPay
            // 
            this.txtAmountToPay.Location = new System.Drawing.Point(910, 740);
            this.txtAmountToPay.Name = "txtAmountToPay";
            this.txtAmountToPay.Size = new System.Drawing.Size(389, 26);
            this.txtAmountToPay.TabIndex = 52;
            // 
            // txtInputMoney
            // 
            this.txtInputMoney.Location = new System.Drawing.Point(910, 820);
            this.txtInputMoney.Name = "txtInputMoney";
            this.txtInputMoney.Size = new System.Drawing.Size(389, 26);
            this.txtInputMoney.TabIndex = 53;
            // 
            // txtChange
            // 
            this.txtChange.Location = new System.Drawing.Point(910, 901);
            this.txtChange.Name = "txtChange";
            this.txtChange.Size = new System.Drawing.Size(389, 26);
            this.txtChange.TabIndex = 54;
            // 
            // WalkInStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(1306, 1034);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.txtInputMoney);
            this.Controls.Add(this.txtAmountToPay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProductViewGridCaloocanInventoryRequestOrder);
            this.Controls.Add(this.cbCategoryFilter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.ProductViewGridCaloocanInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WalkInStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WalkInStore";
            this.Load += new System.EventHandler(this.WalkInStore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductViewGridCaloocanInventoryRequestOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductViewGridCaloocanInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ProductViewGridCaloocanInventoryRequestOrder;
        private System.Windows.Forms.ComboBox cbCategoryFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.DataGridView ProductViewGridCaloocanInventory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmountToPay;
        private System.Windows.Forms.TextBox txtInputMoney;
        private System.Windows.Forms.TextBox txtChange;
    }
}