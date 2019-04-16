
using System;
using System.Windows.Forms;

namespace TransformerBank
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// create new instance of the ATMLogic whiwch is used in all ATMForms to work with data
        /// 
        /// </summary>
        private ATMLogic _logic = new ATMLogic();
        /// <summary>
        /// constructor
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// checks login information if correct new form is opened and we are moved to next form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {


            if ((numericTxtBoxLogin.Text.ToString().Length == 0) || (numericTxtBoxPin.Text.ToString().Length == 0))
            {
                MessageBox.Show("Enter login informations");
            }
            else
            {
                string choice = _logic.CheckCard(numericTxtBoxLogin.Text);
                if (choice.Equals("Good"))
                {
                    if (_logic.CheckPin(numericTxtBoxLogin.Text, Convert.ToInt32(numericTxtBoxPin.Text)))
                    {

                        FrmATMChoosing choosing = new FrmATMChoosing(numericTxtBoxLogin.Text, _logic);
                        _logic.ResetBadAttempts(numericTxtBoxLogin.Text);
                        choosing.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Wrong password combination");
                        if (!_logic.AddBadAttempt(numericTxtBoxLogin.Text))
                        {
                            MessageBox.Show("3 Wrong Attempts Card is Blocked");
                        }
                    }
                }
                else if (choice.Equals("Blocked"))
                {
                    MessageBox.Show("Card is Blocked");
                }
                else if (choice.Equals("WrongLogin"))
                {
                    MessageBox.Show("Wrong Login Name");
                }
            }
        }

        /// <summary>
        /// Close the ATM 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

  
    }
}
