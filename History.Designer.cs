namespace MobileInventory
{
    partial class History
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
            this.btnExportTOExcel = new System.Windows.Forms.Button();
            this.cbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.HistoryGridView = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.HistoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportTOExcel
            // 
            this.btnExportTOExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(195)))), ((int)(((byte)(173)))));
            this.btnExportTOExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportTOExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExportTOExcel.Location = new System.Drawing.Point(12, 6);
            this.btnExportTOExcel.Name = "btnExportTOExcel";
            this.btnExportTOExcel.Size = new System.Drawing.Size(256, 41);
            this.btnExportTOExcel.TabIndex = 28;
            this.btnExportTOExcel.Text = "DOWNLOAD";
            this.btnExportTOExcel.UseVisualStyleBackColor = false;
            this.btnExportTOExcel.Click += new System.EventHandler(this.btnExportTOExcel_Click);
            // 
            // cbCategoryFilter
            // 
            this.cbCategoryFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoryFilter.FormattingEnabled = true;
            this.cbCategoryFilter.Location = new System.Drawing.Point(816, 9);
            this.cbCategoryFilter.Name = "cbCategoryFilter";
            this.cbCategoryFilter.Size = new System.Drawing.Size(193, 33);
            this.cbCategoryFilter.TabIndex = 27;
            this.cbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cbCategoryFilter_SelectedIndexChanged);
            // 
            // HistoryGridView
            // 
            this.HistoryGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(163)))), ((int)(((byte)(176)))));
            this.HistoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HistoryGridView.Location = new System.Drawing.Point(3, 56);
            this.HistoryGridView.Name = "HistoryGridView";
            this.HistoryGridView.RowHeadersWidth = 62;
            this.HistoryGridView.RowTemplate.Height = 28;
            this.HistoryGridView.Size = new System.Drawing.Size(1280, 887);
            this.HistoryGridView.TabIndex = 26;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MobileInventory.Properties.Resources.search__1_;
            this.pictureBox1.Location = new System.Drawing.Point(337, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBar.Location = new System.Drawing.Point(381, 11);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(429, 30);
            this.txtSearchBar.TabIndex = 24;
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.Controls.Add(this.btnExportTOExcel);
            this.Controls.Add(this.cbCategoryFilter);
            this.Controls.Add(this.HistoryGridView);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtSearchBar);
            this.Name = "History";
            this.Size = new System.Drawing.Size(1286, 949);
            this.Load += new System.EventHandler(this.History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HistoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportTOExcel;
        private System.Windows.Forms.ComboBox cbCategoryFilter;
        private System.Windows.Forms.DataGridView HistoryGridView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSearchBar;
    }
}
