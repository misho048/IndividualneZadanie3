namespace BankSystem
{
    partial class frmClientManagement
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
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdCloseAccount = new System.Windows.Forms.Button();
            this.cmdAllTransactions = new System.Windows.Forms.Button();
            this.cmdNewTransaction = new System.Windows.Forms.Button();
            this.buttonNewCreditCard = new System.Windows.Forms.Button();
            this.dGVCreditcards = new System.Windows.Forms.DataGridView();
            this.buttonChangePin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxIDCardNumber = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.textBoxPostalCode = new System.Windows.Forms.TextBox();
            this.textBoxDebtLimit = new System.Windows.Forms.TextBox();
            this.textBoxBalance = new System.Windows.Forms.TextBox();
            this.textBoxIban = new System.Windows.Forms.TextBox();
            this.buttonBlockUnblock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCreditcards)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(825, 93);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(112, 23);
            this.cmdUpdate.TabIndex = 4;
            this.cmdUpdate.Text = "Update info";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdCloseAccount
            // 
            this.cmdCloseAccount.Location = new System.Drawing.Point(829, 363);
            this.cmdCloseAccount.Name = "cmdCloseAccount";
            this.cmdCloseAccount.Size = new System.Drawing.Size(112, 23);
            this.cmdCloseAccount.TabIndex = 6;
            this.cmdCloseAccount.Text = "Close account";
            this.cmdCloseAccount.UseVisualStyleBackColor = true;
            this.cmdCloseAccount.Click += new System.EventHandler(this.cmdCloseAccount_Click);
            // 
            // cmdAllTransactions
            // 
            this.cmdAllTransactions.Location = new System.Drawing.Point(825, 51);
            this.cmdAllTransactions.Name = "cmdAllTransactions";
            this.cmdAllTransactions.Size = new System.Drawing.Size(112, 23);
            this.cmdAllTransactions.TabIndex = 8;
            this.cmdAllTransactions.Text = "All transactions";
            this.cmdAllTransactions.UseVisualStyleBackColor = true;
            this.cmdAllTransactions.Click += new System.EventHandler(this.cmdAllTransactions_Click);
            // 
            // cmdNewTransaction
            // 
            this.cmdNewTransaction.Location = new System.Drawing.Point(825, 12);
            this.cmdNewTransaction.Name = "cmdNewTransaction";
            this.cmdNewTransaction.Size = new System.Drawing.Size(112, 23);
            this.cmdNewTransaction.TabIndex = 5;
            this.cmdNewTransaction.Text = "New transaction";
            this.cmdNewTransaction.UseVisualStyleBackColor = true;
            this.cmdNewTransaction.Click += new System.EventHandler(this.cmdNewTransaction_Click);
            // 
            // buttonNewCreditCard
            // 
            this.buttonNewCreditCard.Location = new System.Drawing.Point(829, 198);
            this.buttonNewCreditCard.Name = "buttonNewCreditCard";
            this.buttonNewCreditCard.Size = new System.Drawing.Size(108, 23);
            this.buttonNewCreditCard.TabIndex = 12;
            this.buttonNewCreditCard.Text = "New credit card";
            this.buttonNewCreditCard.UseVisualStyleBackColor = true;
            this.buttonNewCreditCard.Click += new System.EventHandler(this.buttonNewCreditCard_Click);
            // 
            // dGVCreditcards
            // 
            this.dGVCreditcards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVCreditcards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCreditcards.Location = new System.Drawing.Point(0, 249);
            this.dGVCreditcards.Name = "dGVCreditcards";
            this.dGVCreditcards.RowHeadersVisible = false;
            this.dGVCreditcards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVCreditcards.Size = new System.Drawing.Size(787, 165);
            this.dGVCreditcards.TabIndex = 14;
            // 
            // buttonChangePin
            // 
            this.buttonChangePin.Location = new System.Drawing.Point(829, 249);
            this.buttonChangePin.Name = "buttonChangePin";
            this.buttonChangePin.Size = new System.Drawing.Size(108, 23);
            this.buttonChangePin.TabIndex = 15;
            this.buttonChangePin.Text = "Change Pin";
            this.buttonChangePin.UseVisualStyleBackColor = true;
            this.buttonChangePin.Click += new System.EventHandler(this.buttonChangePin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(91, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(65, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "Surname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "ID card number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(15, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 24);
            this.label5.TabIndex = 20;
            this.label5.Text = "Phone number:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(112, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 24);
            this.label9.TabIndex = 24;
            this.label9.Text = "City:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(41, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 24);
            this.label10.TabIndex = 25;
            this.label10.Text = "Postal Code:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(421, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 24);
            this.label11.TabIndex = 26;
            this.label11.Text = "IBAN:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(396, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 24);
            this.label12.TabIndex = 27;
            this.label12.Text = "Balance:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(388, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 24);
            this.label13.TabIndex = 28;
            this.label13.Text = "Debt limit:";
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxName.Location = new System.Drawing.Point(163, 13);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(210, 22);
            this.textBoxName.TabIndex = 29;
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Enabled = false;
            this.textBoxSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxSurname.Location = new System.Drawing.Point(163, 51);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(210, 22);
            this.textBoxSurname.TabIndex = 30;
            // 
            // textBoxIDCardNumber
            // 
            this.textBoxIDCardNumber.Enabled = false;
            this.textBoxIDCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxIDCardNumber.Location = new System.Drawing.Point(163, 91);
            this.textBoxIDCardNumber.Name = "textBoxIDCardNumber";
            this.textBoxIDCardNumber.Size = new System.Drawing.Size(210, 22);
            this.textBoxIDCardNumber.TabIndex = 31;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Enabled = false;
            this.textBoxPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(163, 137);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(210, 22);
            this.textBoxPhoneNumber.TabIndex = 32;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Enabled = false;
            this.textBoxCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCity.Location = new System.Drawing.Point(163, 174);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(210, 22);
            this.textBoxCity.TabIndex = 33;
            // 
            // textBoxPostalCode
            // 
            this.textBoxPostalCode.Enabled = false;
            this.textBoxPostalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPostalCode.Location = new System.Drawing.Point(163, 212);
            this.textBoxPostalCode.Name = "textBoxPostalCode";
            this.textBoxPostalCode.Size = new System.Drawing.Size(210, 22);
            this.textBoxPostalCode.TabIndex = 34;
            // 
            // textBoxDebtLimit
            // 
            this.textBoxDebtLimit.Enabled = false;
            this.textBoxDebtLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDebtLimit.Location = new System.Drawing.Point(485, 92);
            this.textBoxDebtLimit.Name = "textBoxDebtLimit";
            this.textBoxDebtLimit.Size = new System.Drawing.Size(210, 22);
            this.textBoxDebtLimit.TabIndex = 37;
            // 
            // textBoxBalance
            // 
            this.textBoxBalance.Enabled = false;
            this.textBoxBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxBalance.Location = new System.Drawing.Point(485, 47);
            this.textBoxBalance.Name = "textBoxBalance";
            this.textBoxBalance.Size = new System.Drawing.Size(210, 22);
            this.textBoxBalance.TabIndex = 36;
            // 
            // textBoxIban
            // 
            this.textBoxIban.Enabled = false;
            this.textBoxIban.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxIban.Location = new System.Drawing.Point(485, 9);
            this.textBoxIban.Name = "textBoxIban";
            this.textBoxIban.Size = new System.Drawing.Size(210, 22);
            this.textBoxIban.TabIndex = 35;
            // 
            // buttonBlockUnblock
            // 
            this.buttonBlockUnblock.Location = new System.Drawing.Point(829, 298);
            this.buttonBlockUnblock.Name = "buttonBlockUnblock";
            this.buttonBlockUnblock.Size = new System.Drawing.Size(108, 44);
            this.buttonBlockUnblock.TabIndex = 38;
            this.buttonBlockUnblock.Text = "Block/Unblock Card";
            this.buttonBlockUnblock.UseVisualStyleBackColor = true;
            this.buttonBlockUnblock.Click += new System.EventHandler(this.buttonBlockUnblock_Click);
            // 
            // frmClientManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 410);
            this.Controls.Add(this.buttonBlockUnblock);
            this.Controls.Add(this.textBoxDebtLimit);
            this.Controls.Add(this.textBoxBalance);
            this.Controls.Add(this.textBoxIban);
            this.Controls.Add(this.textBoxPostalCode);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.textBoxIDCardNumber);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonChangePin);
            this.Controls.Add(this.dGVCreditcards);
            this.Controls.Add(this.buttonNewCreditCard);
            this.Controls.Add(this.cmdAllTransactions);
            this.Controls.Add(this.cmdCloseAccount);
            this.Controls.Add(this.cmdNewTransaction);
            this.Controls.Add(this.cmdUpdate);
            this.Name = "frmClientManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmClientManagement";           
            ((System.ComponentModel.ISupportInitialize)(this.dGVCreditcards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdCloseAccount;
        private System.Windows.Forms.Button cmdAllTransactions;
        private System.Windows.Forms.Button cmdNewTransaction;
        private System.Windows.Forms.Button buttonNewCreditCard;
        private System.Windows.Forms.DataGridView dGVCreditcards;
        private System.Windows.Forms.Button buttonChangePin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxIDCardNumber;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.TextBox textBoxPostalCode;
        private System.Windows.Forms.TextBox textBoxDebtLimit;
        private System.Windows.Forms.TextBox textBoxBalance;
        private System.Windows.Forms.TextBox textBoxIban;
        private System.Windows.Forms.Button buttonBlockUnblock;
    }
}