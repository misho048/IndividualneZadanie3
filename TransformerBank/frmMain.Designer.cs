namespace TransformerBank
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
            this.numericTxtBoxLogin = new Controls.NumericTextBox();
            this.numericTxtBoxPin = new Controls.NumericTextBox();
            this.btnComfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Pin = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numericTxtBoxLogin
            // 
            this.numericTxtBoxLogin.Location = new System.Drawing.Point(141, 35);
            this.numericTxtBoxLogin.Name = "numericTxtBoxLogin";
            this.numericTxtBoxLogin.Size = new System.Drawing.Size(188, 20);
            this.numericTxtBoxLogin.TabIndex = 0;
            // 
            // numericTxtBoxPin
            // 
            this.numericTxtBoxPin.Location = new System.Drawing.Point(141, 83);
            this.numericTxtBoxPin.Name = "numericTxtBoxPin";
            this.numericTxtBoxPin.Size = new System.Drawing.Size(188, 20);
            this.numericTxtBoxPin.TabIndex = 1;
            // 
            // btnComfirm
            // 
            this.btnComfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnComfirm.Location = new System.Drawing.Point(105, 237);
            this.btnComfirm.Name = "btnComfirm";
            this.btnComfirm.Size = new System.Drawing.Size(187, 48);
            this.btnComfirm.TabIndex = 2;
            this.btnComfirm.Text = "Confirm";
            this.btnComfirm.UseVisualStyleBackColor = true;
            this.btnComfirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(42, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Login";
            // 
            // Pin
            // 
            this.Pin.AutoSize = true;
            this.Pin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Pin.Location = new System.Drawing.Point(64, 78);
            this.Pin.Name = "Pin";
            this.Pin.Size = new System.Drawing.Size(40, 24);
            this.Pin.TabIndex = 4;
            this.Pin.Text = "Pin";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExit.Location = new System.Drawing.Point(105, 301);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(187, 48);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TransformerBank.Properties.Resources.bank_islam;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.Pin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnComfirm);
            this.Controls.Add(this.numericTxtBoxPin);
            this.Controls.Add(this.numericTxtBoxLogin);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(100, 200);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ATM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.NumericTextBox numericTxtBoxLogin;
        private Controls.NumericTextBox numericTxtBoxPin;
        private System.Windows.Forms.Button btnComfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Pin;
        private System.Windows.Forms.Button btnExit;
    }
}

