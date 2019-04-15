namespace BankSystem
{
    partial class frmNewCreditcard
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelPin = new System.Windows.Forms.Label();
            this.labelCardGenerated = new System.Windows.Forms.Label();
            this.labelConfirmPin = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.numericTextBoxPin = new Controls.NumericTextBox();
            this.numericTextBoxPinConfirm = new Controls.NumericTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Card number:";
            // 
            // labelPin
            // 
            this.labelPin.AutoSize = true;
            this.labelPin.Location = new System.Drawing.Point(152, 121);
            this.labelPin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPin.Name = "labelPin";
            this.labelPin.Size = new System.Drawing.Size(46, 24);
            this.labelPin.TabIndex = 1;
            this.labelPin.Text = "Pin:";
            // 
            // labelCardGenerated
            // 
            this.labelCardGenerated.AutoSize = true;
            this.labelCardGenerated.Location = new System.Drawing.Point(223, 70);
            this.labelCardGenerated.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelCardGenerated.Name = "labelCardGenerated";
            this.labelCardGenerated.Size = new System.Drawing.Size(138, 24);
            this.labelCardGenerated.TabIndex = 2;
            this.labelCardGenerated.Text = "Card number:";
            // 
            // labelConfirmPin
            // 
            this.labelConfirmPin.AutoSize = true;
            this.labelConfirmPin.Location = new System.Drawing.Point(74, 163);
            this.labelConfirmPin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelConfirmPin.Name = "labelConfirmPin";
            this.labelConfirmPin.Size = new System.Drawing.Size(124, 24);
            this.labelConfirmPin.TabIndex = 3;
            this.labelConfirmPin.Text = "Confirm Pin:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(96, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 50);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(259, 221);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(102, 50);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericTextBoxPin
            // 
            this.numericTextBoxPin.Location = new System.Drawing.Point(227, 118);
            this.numericTextBoxPin.Name = "numericTextBoxPin";
            this.numericTextBoxPin.Size = new System.Drawing.Size(134, 29);
            this.numericTextBoxPin.TabIndex = 6;
            // 
            // numericTextBoxPinConfirm
            // 
            this.numericTextBoxPinConfirm.Location = new System.Drawing.Point(227, 163);
            this.numericTextBoxPinConfirm.Name = "numericTextBoxPinConfirm";
            this.numericTextBoxPinConfirm.Size = new System.Drawing.Size(134, 29);
            this.numericTextBoxPinConfirm.TabIndex = 7;
            // 
            // frmNewCreditcard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 309);
            this.Controls.Add(this.numericTextBoxPinConfirm);
            this.Controls.Add(this.numericTextBoxPin);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelConfirmPin);
            this.Controls.Add(this.labelCardGenerated);
            this.Controls.Add(this.labelPin);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmNewCreditcard";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPin;
        private System.Windows.Forms.Label labelCardGenerated;
        private System.Windows.Forms.Label labelConfirmPin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private Controls.NumericTextBox numericTextBoxPin;
        private Controls.NumericTextBox numericTextBoxPinConfirm;
    }
}