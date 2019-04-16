namespace BankSystem
{
    partial class frmTransaction
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
            this.numericTextBoxValue = new Controls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTransType = new System.Windows.Forms.ComboBox();
            this.labelIban = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.labelVS = new System.Windows.Forms.Label();
            this.labelSS = new System.Windows.Forms.Label();
            this.labelCS = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxIban = new System.Windows.Forms.TextBox();
            this.textBoxVS = new System.Windows.Forms.TextBox();
            this.textBoxSS = new System.Windows.Forms.TextBox();
            this.textBoxCS = new System.Windows.Forms.TextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // numericTextBoxValue
            // 
            this.numericTextBoxValue.Location = new System.Drawing.Point(413, 20);
            this.numericTextBoxValue.Name = "numericTextBoxValue";
            this.numericTextBoxValue.Size = new System.Drawing.Size(165, 20);
            this.numericTextBoxValue.TabIndex = 0;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(79, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Value ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(584, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "€";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Type of Transaction";
            // 
            // comboBoxTransType
            // 
            this.comboBoxTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransType.FormattingEnabled = true;
            this.comboBoxTransType.Items.AddRange(new object[] {
            "Deposit ",
            "Withdraw",
            "Regular Transaction"});
            this.comboBoxTransType.Location = new System.Drawing.Point(413, 61);
            this.comboBoxTransType.Name = "comboBoxTransType";
            this.comboBoxTransType.Size = new System.Drawing.Size(165, 21);
            this.comboBoxTransType.TabIndex = 4;
            this.comboBoxTransType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelIban
            // 
            this.labelIban.AutoSize = true;
            this.labelIban.Enabled = false;
            this.labelIban.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelIban.Location = new System.Drawing.Point(12, 96);
            this.labelIban.Name = "labelIban";
            this.labelIban.Size = new System.Drawing.Size(63, 24);
            this.labelIban.TabIndex = 5;
            this.labelIban.Text = "IBAN:";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonConfirm.Location = new System.Drawing.Point(455, 289);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(150, 35);
            this.buttonConfirm.TabIndex = 6;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // labelVS
            // 
            this.labelVS.AutoSize = true;
            this.labelVS.Enabled = false;
            this.labelVS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVS.Location = new System.Drawing.Point(12, 135);
            this.labelVS.Name = "labelVS";
            this.labelVS.Size = new System.Drawing.Size(168, 24);
            this.labelVS.TabIndex = 7;
            this.labelVS.Text = "Variable Symbol:";
            // 
            // labelSS
            // 
            this.labelSS.AutoSize = true;
            this.labelSS.Enabled = false;
            this.labelSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSS.Location = new System.Drawing.Point(12, 170);
            this.labelSS.Name = "labelSS";
            this.labelSS.Size = new System.Drawing.Size(165, 24);
            this.labelSS.TabIndex = 8;
            this.labelSS.Text = "Specific Symbol:";
            // 
            // labelCS
            // 
            this.labelCS.AutoSize = true;
            this.labelCS.Enabled = false;
            this.labelCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCS.Location = new System.Drawing.Point(12, 209);
            this.labelCS.Name = "labelCS";
            this.labelCS.Size = new System.Drawing.Size(172, 24);
            this.labelCS.TabIndex = 9;
            this.labelCS.Text = "Constant Symbol:";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Enabled = false;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMessage.Location = new System.Drawing.Point(12, 244);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(196, 24);
            this.labelMessage.TabIndex = 10;
            this.labelMessage.Text = "Message for Moron:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCancel.Location = new System.Drawing.Point(16, 289);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(150, 35);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxIban
            // 
            this.textBoxIban.Enabled = false;
            this.textBoxIban.Location = new System.Drawing.Point(214, 96);
            this.textBoxIban.Name = "textBoxIban";
            this.textBoxIban.Size = new System.Drawing.Size(364, 20);
            this.textBoxIban.TabIndex = 12;
            // 
            // textBoxVS
            // 
            this.textBoxVS.Enabled = false;
            this.textBoxVS.Location = new System.Drawing.Point(214, 135);
            this.textBoxVS.Name = "textBoxVS";
            this.textBoxVS.Size = new System.Drawing.Size(364, 20);
            this.textBoxVS.TabIndex = 13;
            // 
            // textBoxSS
            // 
            this.textBoxSS.Enabled = false;
            this.textBoxSS.Location = new System.Drawing.Point(214, 170);
            this.textBoxSS.Name = "textBoxSS";
            this.textBoxSS.Size = new System.Drawing.Size(364, 20);
            this.textBoxSS.TabIndex = 14;
            // 
            // textBoxCS
            // 
            this.textBoxCS.Enabled = false;
            this.textBoxCS.Location = new System.Drawing.Point(214, 209);
            this.textBoxCS.Name = "textBoxCS";
            this.textBoxCS.Size = new System.Drawing.Size(364, 20);
            this.textBoxCS.TabIndex = 15;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Enabled = false;
            this.textBoxMessage.Location = new System.Drawing.Point(214, 244);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(364, 20);
            this.textBoxMessage.TabIndex = 16;
            // 
            // frmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 336);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.textBoxCS);
            this.Controls.Add(this.textBoxSS);
            this.Controls.Add(this.textBoxVS);
            this.Controls.Add(this.textBoxIban);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelCS);
            this.Controls.Add(this.labelSS);
            this.Controls.Add(this.labelVS);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labelIban);
            this.Controls.Add(this.comboBoxTransType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericTextBoxValue);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmTransaction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.NumericTextBox numericTextBoxValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTransType;
        private System.Windows.Forms.Label labelIban;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label labelVS;
        private System.Windows.Forms.Label labelSS;
        private System.Windows.Forms.Label labelCS;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxIban;
        private System.Windows.Forms.TextBox textBoxVS;
        private System.Windows.Forms.TextBox textBoxSS;
        private System.Windows.Forms.TextBox textBoxCS;
        private System.Windows.Forms.TextBox textBoxMessage;
    }
}