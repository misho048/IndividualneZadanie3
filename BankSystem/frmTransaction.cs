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
    public partial class frmTransaction : Form
    {
        private BSLogic _logic;
        private string _clientIdCard;

        public frmTransaction(BSLogic logic ,string clientIdCard)
        {
            InitializeComponent();
            _logic = logic;
            _clientIdCard = clientIdCard;
        }

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

        private void numericTextBoxValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            _logic.SaveTransaction(Convert.ToDecimal(numericTextBoxValue.Text), comboBoxTransType.Text, textBoxIban.Text,
                textBoxVS.Text, textBoxSS.Text, textBoxCS.Text, textBoxMessage.Text,_clientIdCard);
            




            DialogResult = DialogResult.OK;
        }
    }
}
