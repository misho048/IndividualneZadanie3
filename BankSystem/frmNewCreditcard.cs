using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class frmNewCreditcard : Form
    {
        private  BSLogic _logic;
        private string _clientCardID;
        private bool _isNew;
        
        public frmNewCreditcard(BSLogic logic, string clientCardID,bool isNew)
        {
            _isNew = isNew;
            InitializeComponent();           
            _logic = logic;
            _clientCardID = clientCardID;
            if (isNew)
            {
                labelCardGenerated.Text = _logic.GenerateCardNumber();
            }
            else
            {
                labelCardGenerated.Text = clientCardID;
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((numericTextBoxPin.Text.Equals(numericTextBoxPinConfirm.Text)) && numericTextBoxPin.Text.Length.Equals(4))
            {
                if (_isNew)
                {
                    _logic.CreateNewCreditcard(_clientCardID, Convert.ToInt32(numericTextBoxPinConfirm.Text), labelCardGenerated.Text);
                }
                else
                {
                    _logic.ResetPin(_clientCardID, Convert.ToInt32(numericTextBoxPinConfirm.Text));
                }
                DialogResult = DialogResult.OK;

            }
            else
            {
                if (numericTextBoxPin.Text.Length.Equals(4))
                {
                    MessageBox.Show("Pins needs to match");
                }
                else
                {
                    MessageBox.Show("Pins need to be exactly  4 digits long, and need to match");
            }
            }
        }
    }
}
