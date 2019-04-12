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
    public partial class ATMBalance : Form
    {
        private ATMLogic _logic;
        private string _login;
        public ATMBalance(ATMLogic logic,string login)
        {
            _logic = logic;
            _login = login;
            InitializeComponent();
            FillLabels();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void FillLabels()
        {
           
            labelIBAN.Text = _logic.GetBalance(_login).IBAN;
            labelBalance.Text= _logic.GetBalance(_login).Balance.ToString();
            labelDebtLimit.Text = _logic.GetBalance(_login).DebtLimit.ToString();
            labelName.Text = _logic.OwnerNameByCardNumber(_login);
          
        }

        private void ATMBalance_Load(object sender, EventArgs e)
        {

        }
    }
}
