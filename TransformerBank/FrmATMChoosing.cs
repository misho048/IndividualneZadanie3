using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformerBank
{
    public partial class FrmATMChoosing : Form
    {
        private ATMLogic _logic;
        private string _cardNumber;

        public FrmATMChoosing(string cardNumber)
        {
            _logic = new ATMLogic();
            _cardNumber = cardNumber;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ATMwithdraw atmFormwithdraw = new ATMwithdraw(_cardNumber, _logic);
            atmFormwithdraw.ShowDialog();
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            ATMBalance balance = new ATMBalance(_logic, _cardNumber);
            balance.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
