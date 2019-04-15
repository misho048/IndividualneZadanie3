namespace BankSystem
{
    partial class frmMain
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
            this.cmdFindClient = new System.Windows.Forms.Button();
            this.cmdNewAccount = new System.Windows.Forms.Button();
            this.cmdAllAccounts = new System.Windows.Forms.Button();
            this.cmdAllTransactions = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dGVManagerOverview = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonTopClients = new System.Windows.Forms.Button();
            this.buttonBankAssets = new System.Windows.Forms.Button();
            this.buttonNumberAccounts = new System.Windows.Forms.Button();
            this.buttonnumberAccountsIn = new System.Windows.Forms.Button();
            this.buttonDemography = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVManagerOverview)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdFindClient
            // 
            this.cmdFindClient.Location = new System.Drawing.Point(510, 21);
            this.cmdFindClient.Name = "cmdFindClient";
            this.cmdFindClient.Size = new System.Drawing.Size(112, 23);
            this.cmdFindClient.TabIndex = 2;
            this.cmdFindClient.Text = "Find client";
            this.cmdFindClient.UseVisualStyleBackColor = true;
            this.cmdFindClient.Click += new System.EventHandler(this.cmdFindClient_Click);
            // 
            // cmdNewAccount
            // 
            this.cmdNewAccount.Location = new System.Drawing.Point(510, 145);
            this.cmdNewAccount.Name = "cmdNewAccount";
            this.cmdNewAccount.Size = new System.Drawing.Size(112, 23);
            this.cmdNewAccount.TabIndex = 3;
            this.cmdNewAccount.Text = "New account";
            this.cmdNewAccount.UseVisualStyleBackColor = true;
            this.cmdNewAccount.Click += new System.EventHandler(this.cmdNewAccount_Click);
            // 
            // cmdAllAccounts
            // 
            this.cmdAllAccounts.Location = new System.Drawing.Point(510, 183);
            this.cmdAllAccounts.Name = "cmdAllAccounts";
            this.cmdAllAccounts.Size = new System.Drawing.Size(112, 23);
            this.cmdAllAccounts.TabIndex = 4;
            this.cmdAllAccounts.Text = "All accounts";
            this.cmdAllAccounts.UseVisualStyleBackColor = true;
            this.cmdAllAccounts.Click += new System.EventHandler(this.cmdAllAccounts_Click);
            // 
            // cmdAllTransactions
            // 
            this.cmdAllTransactions.Location = new System.Drawing.Point(510, 225);
            this.cmdAllTransactions.Name = "cmdAllTransactions";
            this.cmdAllTransactions.Size = new System.Drawing.Size(112, 23);
            this.cmdAllTransactions.TabIndex = 5;
            this.cmdAllTransactions.Text = "All transactions";
            this.cmdAllTransactions.UseVisualStyleBackColor = true;
            this.cmdAllTransactions.Click += new System.EventHandler(this.cmdAllTransactions_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(395, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.TextUpdate += new System.EventHandler(this.comboBox1_TextUpdate);
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // dGVManagerOverview
            // 
            this.dGVManagerOverview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVManagerOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVManagerOverview.Location = new System.Drawing.Point(11, 14);
            this.dGVManagerOverview.MultiSelect = false;
            this.dGVManagerOverview.Name = "dGVManagerOverview";
            this.dGVManagerOverview.ReadOnly = true;
            this.dGVManagerOverview.RowHeadersVisible = false;
            this.dGVManagerOverview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVManagerOverview.Size = new System.Drawing.Size(280, 344);
            this.dGVManagerOverview.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonTopClients
            // 
            this.buttonTopClients.Location = new System.Drawing.Point(297, 170);
            this.buttonTopClients.Name = "buttonTopClients";
            this.buttonTopClients.Size = new System.Drawing.Size(112, 23);
            this.buttonTopClients.TabIndex = 13;
            this.buttonTopClients.Text = "Top Clients";
            this.buttonTopClients.UseVisualStyleBackColor = true;
            this.buttonTopClients.Click += new System.EventHandler(this.buttonTopClients_Click);
            // 
            // buttonBankAssets
            // 
            this.buttonBankAssets.Location = new System.Drawing.Point(297, 199);
            this.buttonBankAssets.Name = "buttonBankAssets";
            this.buttonBankAssets.Size = new System.Drawing.Size(112, 23);
            this.buttonBankAssets.TabIndex = 14;
            this.buttonBankAssets.Text = "Bank Assets";
            this.buttonBankAssets.UseVisualStyleBackColor = true;
            this.buttonBankAssets.Click += new System.EventHandler(this.buttonBankAssets_Click);
            // 
            // buttonNumberAccounts
            // 
            this.buttonNumberAccounts.Location = new System.Drawing.Point(297, 228);
            this.buttonNumberAccounts.Name = "buttonNumberAccounts";
            this.buttonNumberAccounts.Size = new System.Drawing.Size(112, 23);
            this.buttonNumberAccounts.TabIndex = 15;
            this.buttonNumberAccounts.Text = "Number of Accounts";
            this.buttonNumberAccounts.UseVisualStyleBackColor = true;
            this.buttonNumberAccounts.Click += new System.EventHandler(this.buttonNumberAccounts_Click);
            // 
            // buttonnumberAccountsIn
            // 
            this.buttonnumberAccountsIn.Location = new System.Drawing.Point(297, 257);
            this.buttonnumberAccountsIn.Name = "buttonnumberAccountsIn";
            this.buttonnumberAccountsIn.Size = new System.Drawing.Size(112, 46);
            this.buttonnumberAccountsIn.TabIndex = 16;
            this.buttonnumberAccountsIn.Text = "Accounts in last 6 months";
            this.buttonnumberAccountsIn.UseVisualStyleBackColor = true;
            this.buttonnumberAccountsIn.Click += new System.EventHandler(this.buttonnumberAccountsIn_Click);
            // 
            // buttonDemography
            // 
            this.buttonDemography.Location = new System.Drawing.Point(297, 309);
            this.buttonDemography.Name = "buttonDemography";
            this.buttonDemography.Size = new System.Drawing.Size(112, 23);
            this.buttonDemography.TabIndex = 17;
            this.buttonDemography.Text = "Demography";
            this.buttonDemography.UseVisualStyleBackColor = true;
            this.buttonDemography.Click += new System.EventHandler(this.buttonDemography_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.buttonDemography);
            this.Controls.Add(this.buttonnumberAccountsIn);
            this.Controls.Add(this.buttonNumberAccounts);
            this.Controls.Add(this.buttonBankAssets);
            this.Controls.Add(this.buttonTopClients);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dGVManagerOverview);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cmdAllTransactions);
            this.Controls.Add(this.cmdAllAccounts);
            this.Controls.Add(this.cmdNewAccount);
            this.Controls.Add(this.cmdFindClient);
            this.Location = new System.Drawing.Point(600, 200);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Bank System";
            ((System.ComponentModel.ISupportInitialize)(this.dGVManagerOverview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdFindClient;
        private System.Windows.Forms.Button cmdNewAccount;
        private System.Windows.Forms.Button cmdAllAccounts;
        private System.Windows.Forms.Button cmdAllTransactions;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dGVManagerOverview;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonTopClients;
        private System.Windows.Forms.Button buttonBankAssets;
        private System.Windows.Forms.Button buttonNumberAccounts;
        private System.Windows.Forms.Button buttonnumberAccountsIn;
        private System.Windows.Forms.Button buttonDemography;
    }
}

