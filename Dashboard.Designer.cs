namespace MobileInventory
{
    partial class Dashboard
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
            this.dataGridViewNotif = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewNewlyAddedProd = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNewlyAddedProd)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewNotif
            // 
            this.dataGridViewNotif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNotif.Location = new System.Drawing.Point(3, 4);
            this.dataGridViewNotif.Name = "dataGridViewNotif";
            this.dataGridViewNotif.RowHeadersWidth = 62;
            this.dataGridViewNotif.RowTemplate.Height = 28;
            this.dataGridViewNotif.Size = new System.Drawing.Size(636, 877);
            this.dataGridViewNotif.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(644, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 37);
            this.label7.TabIndex = 11;
            this.label7.Text = "new phones";
            // 
            // dataGridViewNewlyAddedProd
            // 
            this.dataGridViewNewlyAddedProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNewlyAddedProd.Location = new System.Drawing.Point(3, 4);
            this.dataGridViewNewlyAddedProd.Name = "dataGridViewNewlyAddedProd";
            this.dataGridViewNewlyAddedProd.RowHeadersWidth = 62;
            this.dataGridViewNewlyAddedProd.RowTemplate.Height = 28;
            this.dataGridViewNewlyAddedProd.Size = new System.Drawing.Size(618, 877);
            this.dataGridViewNewlyAddedProd.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(187)))), ((int)(((byte)(175)))));
            this.panel7.Controls.Add(this.dataGridViewNewlyAddedProd);
            this.panel7.Location = new System.Drawing.Point(648, 55);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(624, 884);
            this.panel7.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 37);
            this.label6.TabIndex = 10;
            this.label6.Text = "phone stocks";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(187)))), ((int)(((byte)(175)))));
            this.panel6.Controls.Add(this.dataGridViewNotif);
            this.panel6.Location = new System.Drawing.Point(3, 55);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(642, 884);
            this.panel6.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(4, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1278, 942);
            this.panel4.TabIndex = 5;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.Controls.Add(this.panel4);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(1286, 949);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNewlyAddedProd)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewNotif;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewNewlyAddedProd;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
    }
}
