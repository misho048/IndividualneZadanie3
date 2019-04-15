namespace BankSystem
{
    partial class frmTransactions
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
            this.dGVTransactions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGVTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVTransactions
            // 
            this.dGVTransactions.AllowUserToAddRows = false;
            this.dGVTransactions.AllowUserToDeleteRows = false;
            this.dGVTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVTransactions.Location = new System.Drawing.Point(28, 12);
            this.dGVTransactions.MultiSelect = false;
            this.dGVTransactions.Name = "dGVTransactions";
            this.dGVTransactions.ReadOnly = true;
            this.dGVTransactions.RowHeadersVisible = false;
            this.dGVTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVTransactions.Size = new System.Drawing.Size(829, 348);
            this.dGVTransactions.TabIndex = 0;
            this.dGVTransactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVTransactions_CellContentClick);
            // 
            // frmTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 361);
            this.Controls.Add(this.dGVTransactions);
            this.Name = "frmTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTransactions";
            ((System.ComponentModel.ISupportInitialize)(this.dGVTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVTransactions;
    }
}