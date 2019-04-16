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
/// form for making a new transaction
/// </summary>
    public partial class frmTransaction : Form
    {
        /// <summary>
        /// using logic and client card information here
        /// duh
        /// </summary>
        private BSLogic _logic;
        private string _clientIdCard;

        /// <summary>
        /// constructor         
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="clientIdCard"></param>
        public frmTransaction(BSLogic logic, string clientIdCard)
        {
            InitializeComponent();
            _logic = logic;
            _clientIdCard = clientIdCard;
        }


        /// <summary>
        /// if we are making withdraw or deposit we dont need Iban
        /// only on regular transaction Iban and other information is needed
        /// so here we are enabling/ disabling ability to write them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTransType.SelectedIndex == 2)
            {
                labelIban.Enabled = true;
                labelCS.Enabled = true;
                labelMessage.Enabled = true;
                labelSS.Enabled = true;
                labelVS.Enabled = true;
                textBoxCS.Enabled = true;
                textBoxIban.Enabled = true;
                textBoxMessage.Enabled = true;
                textBoxVS.Enabled = true;
                textBoxSS.Enabled = true;
            }
            else
            {
                labelIban.Enabled = false;
                labelCS.Enabled = false;
                labelMessage.Enabled = false;
                labelSS.Enabled = false;
                labelVS.Enabled = false;
                textBoxCS.Enabled = false;
                textBoxIban.Enabled = false;
                textBoxMessage.Enabled = false;
                textBoxVS.Enabled = false;
                textBoxSS.Enabled = false;
            }
        }


        /// <summary>
        /// cancel button leave form withou saving changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// checks the funds and IBan
        /// if everuthing is OK transaction si made and we leave this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if ((_logic.IsTransactionPossible(_clientIdCard, Convert.ToDecimal(numericTextBoxValue.Text))) || (comboBoxTransType.Text.Contains("Deposit") ))
            {
                if (comboBoxTransType.Text.Equals("Regular Transaction"))
                {
                    if (_logic.GetAllIbans().Contains(textBoxIban.Text))
                    {

                        _logic.SaveTransaction(Convert.ToDecimal(numericTextBoxValue.Text), comboBoxTransType.Text, textBoxIban.Text,
                        textBoxVS.Text, textBoxSS.Text, textBoxCS.Text, textBoxMessage.Text, _clientIdCard);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Wrong IBAN");
                    }
                }
                else
                {
                    _logic.SaveTransaction(Convert.ToDecimal(numericTextBoxValue.Text), comboBoxTransType.Text, textBoxIban.Text,
                    textBoxVS.Text, textBoxSS.Text, textBoxCS.Text, textBoxMessage.Text, _clientIdCard);





                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Not enough FUnds");
            }
        }
    }
}
