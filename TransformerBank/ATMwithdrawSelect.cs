using System;

using System.Windows.Forms;

namespace TransformerBank
{/// <summary>
/// this class is for Bank Note withdrawal in ATM
/// </summary>
    public partial class ATMwithdrawSelect : Form
    {
        /// <summary>
        /// we using ATMlogic here, cardnumber
        /// and onther variables are to save amount of bank notes to withdraw
        /// </summary>
        private string _cardNumber;
        private ATMLogic _logic;
        private int note5 = 0;
        private int note10 = 0;
        private int note20 = 0;
        private int note50 = 0;
        private int note100 = 0;
        private int note500 = 0;



        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="logic"></param>
        public ATMwithdrawSelect(string cardNumber, ATMLogic logic)
        {
            _cardNumber = cardNumber;
            _logic = logic;
            InitializeComponent();
        }
        /// <summary>
        /// end current form with a cancel dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncancel_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// makes the withdraw (if possible )
        /// count the value 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            decimal value = note5 * 5 + note10 * 10 + note20 * 20 + note50 * 50 + note100 * 100 + note500 * 500;
            if (
            _logic.AddWithdrawTransaction(value, _cardNumber))
            {

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Not enough funds");
            }
        }


        /// <summary>
        /// all nbext methods just save the value and draw number of counts on themselfs
        /// </summary>

        private void btn5_Click(object sender, EventArgs e)
        {
            note5++;
            btn5.Text = note5.ToString();
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            note20++;
            btn20.Text = note20.ToString();
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            note100++;
            btn100.Text = note100.ToString();
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            note10++;
            btn10.Text = note10.ToString();
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            note50++;
            btn50.Text = note50.ToString();
        }

        private void btn200_Click(object sender, EventArgs e)
        {
            note500++;
            btn500.Text = note500.ToString();
        }
    }
}
