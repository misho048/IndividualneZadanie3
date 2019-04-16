using System;
using System.Linq;
using System.Windows.Forms;

namespace TransformerBank
{
    public partial class ATMwithdraw : Form
    {
        /// <summary>
        /// saving creditcardnumber
        /// using logic
        /// value for counting amount to withdraw
        /// </summary>
        private string _cardNumber;
        private ATMLogic _logic;
        private decimal _value=0;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="logic"></param>
        public ATMwithdraw( string cardNumber,ATMLogic logic)
        {
            _cardNumber = cardNumber;
            _logic = logic;
            InitializeComponent();
        }

        /// <summary>
        /// method for clearing "X" at the buttons
        /// </summary>
        private void ClearChoice()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.ResetText();
            }
        }
               
        /// <summary>
        /// Cancel button to leave form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// button to go to next form when you can choose bank notes
        /// if withdraw will be done at next form this will close this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            ATMwithdrawSelect atmForm = new ATMwithdrawSelect(_cardNumber, _logic);
            atmForm.ShowDialog();
            if (atmForm.DialogResult == DialogResult.OK)
            {
                _value = 0;
                btnConfirm.PerformClick();
            }

        }

        /// <summary>
        /// button to confirm transaction
        /// end this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn5_Click(object sender, EventArgs e)
        {
            if (_value != 0)
            {
                _logic.AddWithdrawTransaction(_value, _cardNumber);
            }
            DialogResult = DialogResult.OK;
           
        }

        /// <summary>
        /// all next methods just change selected value and saves it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn5_Click_1(object sender, EventArgs e)
        {
            ClearChoice();
            btn5.Text = "X";
            _value = 5;
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            ClearChoice();
            btn20.Text = "X";
            _value = 20;
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            ClearChoice();
            btn10.Text = "X";
            _value = 10;
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            ClearChoice();
            btn50.Text = "X";
            _value = 50;
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            ClearChoice();
            btn100.Text = "X";
            _value = 100;
        }
    }
}
