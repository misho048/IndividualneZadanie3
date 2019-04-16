namespace BankSystem
{
    partial class frmAccounts
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
            this.cmdManageAccount = new System.Windows.Forms.Button();
            this.dGVAccounts = new System.Windows.Forms.DataGridView();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonLastName = new System.Windows.Forms.RadioButton();
            this.radioButtonIban = new System.Windows.Forms.RadioButton();
            this.radioButtonFirstName = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdManageAccount
            // 
            this.cmdManageAccount.Location = new System.Drawing.Point(744, 12);
            this.cmdManageAccount.Name = "cmdManageAccount";
            this.cmdManageAccount.Size = new System.Drawing.Size(158, 99);
            this.cmdManageAccount.TabIndex = 10;
            this.cmdManageAccount.Text = "Manage account";
            this.cmdManageAccount.UseVisualStyleBackColor = true;
            this.cmdManageAccount.Click += new System.EventHandler(this.cmdManageAccount_Click);
            // 
            // dGVAccounts
            // 
            this.dGVAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVAccounts.Location = new System.Drawing.Point(0, 199);
            this.dGVAccounts.MultiSelect = false;
            this.dGVAccounts.Name = "dGVAccounts";
            this.dGVAccounts.ReadOnly = true;
            this.dGVAccounts.RowHeadersVisible = false;
            this.dGVAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVAccounts.Size = new System.Drawing.Size(890, 312);
            this.dGVAccounts.TabIndex = 11;

            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(406, 75);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(174, 20);
            this.textBoxFilter.TabIndex = 12;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "IBAN";
            // 
            // radioButtonLastName
            // 
            this.radioButtonLastName.AutoSize = true;
            this.radioButtonLastName.Location = new System.Drawing.Point(253, 78);
            this.radioButtonLastName.Name = "radioButtonLastName";
            this.radioButtonLastName.Size = new System.Drawing.Size(14, 13);
            this.radioButtonLastName.TabIndex = 18;
            this.radioButtonLastName.TabStop = true;
            this.radioButtonLastName.UseVisualStyleBackColor = true;
            // 
            // radioButtonIban
            // 
            this.radioButtonIban.AutoSize = true;
            this.radioButtonIban.Location = new System.Drawing.Point(253, 131);
            this.radioButtonIban.Name = "radioButtonIban";
            this.radioButtonIban.Size = new System.Drawing.Size(14, 13);
            this.radioButtonIban.TabIndex = 19;
            this.radioButtonIban.TabStop = true;
            this.radioButtonIban.UseVisualStyleBackColor = true;
            // 
            // radioButtonFirstName
            // 
            this.radioButtonFirstName.AutoSize = true;
            this.radioButtonFirstName.Location = new System.Drawing.Point(253, 25);
            this.radioButtonFirstName.Name = "radioButtonFirstName";
            this.radioButtonFirstName.Size = new System.Drawing.Size(14, 13);
            this.radioButtonFirstName.TabIndex = 20;
            this.radioButtonFirstName.TabStop = true;
            this.radioButtonFirstName.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Filter";
            // 
            // frmAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 508);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioButtonFirstName);
            this.Controls.Add(this.radioButtonIban);
            this.Controls.Add(this.radioButtonLastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.dGVAccounts);
            this.Controls.Add(this.cmdManageAccount);
            this.Name = "frmAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmClients";
            ((System.ComponentModel.ISupportInitialize)(this.dGVAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdManageAccount;
        private System.Windows.Forms.DataGridView dGVAccounts;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonLastName;
        private System.Windows.Forms.RadioButton radioButtonIban;
        private System.Windows.Forms.RadioButton radioButtonFirstName;
        private System.Windows.Forms.Label label4;
    }
}