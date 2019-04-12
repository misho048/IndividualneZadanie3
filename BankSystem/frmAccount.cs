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
    public partial class frmAccount : Form
    {
        BSLogic _logic;
        /// <summary>
        /// Used when adding new account.
        /// </summary>
        public frmAccount(BSLogic logic)
        {
            _logic = logic;
            InitializeComponent();
            labelIban.Text = _logic.GenerateIBAN();
        }

        /// <summary>
        /// Used when viewing/updating existing account.
        /// </summary>
        /// <param name="clientId"></param>
        public frmAccount(int clientId)
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            _logic.CreateUser(txtboxFirstName.Text, txtBoxSurname.Text, txtBoxIDCardNumber.Text,
                txtBoxPhoneNumber.Text, txtBoxEmail.Text, txtBoxStreetName.Text, Convert.ToInt32(txtHomeNumber.Text),
                txtBoxCity.Text, txtBoxPostalCode.Text,Convert.ToDecimal(cmbBoxDebetLimit.Text));


            DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
