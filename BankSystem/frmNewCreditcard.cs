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
{/// <summary>
/// Form to create new credit card or to change pincode
/// </summary>
    public partial class frmNewCreditcard : Form
    {
        /// <summary>
        /// logic is used here with client card information
        /// is new  is identificator if we are creating new card or changing pincode to old one
        /// </summary>
        private  BSLogic _logic;
        private string _clientCardID;
        private bool _isNew;
       
        /// <summary>
        /// construcotr
        /// label text is generated if is new or is copyied if id old
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="clientCardID"></param>
        /// <param name="isNew"></param>
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

        /// <summary>
        /// cancel byutton leaves the form without saving changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        /// <summary>
        /// confirm leaving the form and creating / chaging pin based on _isNew value
        /// and also checks the pin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
