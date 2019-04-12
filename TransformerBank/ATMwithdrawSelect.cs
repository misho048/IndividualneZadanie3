using System;

using System.Windows.Forms;

namespace TransformerBank
{
    public partial class ATMwithdrawSelect : Form
    {
        private string _cardNumber;
        private ATMLogic _logic;
        private int note5=0;
        private int note10 = 0;
        private int note20 = 0;
        private int note50 = 0;
        private int note100 = 0;
        private int note500 = 0;




        public ATMwithdrawSelect(string cardNumber,ATMLogic logic)
        {
            _cardNumber = cardNumber;
            _logic = logic;
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            decimal value = note5 * 5 + note10 * 10 + note20 * 20 + note50 * 50 + note100 * 100 + note500 * 500;
            _logic.AddWithdrawTransaction(value, _cardNumber);
            DialogResult = DialogResult.OK;
        }

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
