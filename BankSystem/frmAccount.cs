using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class frmAccount : Form
    {
        private BSLogic _logic;
        private string _clientIdCard;
        private bool _isUpdate;
        private string[] _dataToShow;

        public frmAccount(BSLogic logic, string clientIdCard)
        {
            _logic = logic;
            InitializeComponent();
            _clientIdCard = clientIdCard;
            readyForUpdate();
            _isUpdate = true;
            
            
        }
        /// <summary>
        /// Used when adding new account.
        /// </summary>
        public frmAccount(BSLogic logic)
        {
            _logic = logic;
            InitializeComponent();
            labelIban.Text = _logic.GenerateIBAN();
            _isUpdate = false;
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
            if (_isUpdate) {
                _dataToShow[1] = txtboxFirstName.Text;
                _dataToShow[2] = txtBoxSurname.Text;
                _dataToShow[3] = txtBoxIDCardNumber.Text;
                _dataToShow[4] = txtBoxPhoneNumber.Text;
                _dataToShow[5] = txtBoxEmail.Text;
                _dataToShow[8] = txtBoxStreetName.Text;
                _dataToShow[9] = txtHomeNumber.Text;
                _dataToShow[10] = txtBoxCity.Text;
                _dataToShow[11] = txtBoxPostalCode.Text;
                _dataToShow[12] = labelIban.Text;
                _dataToShow[13] = cmbBoxDebetLimit.Text;                
                _logic.UpdateUserInfo(_dataToShow);

            }
            else
            {
                _logic.CreateUser(txtboxFirstName.Text, txtBoxSurname.Text, txtBoxIDCardNumber.Text,
                    txtBoxPhoneNumber.Text, txtBoxEmail.Text, txtBoxStreetName.Text, Convert.ToInt32(txtHomeNumber.Text),
                    txtBoxCity.Text, txtBoxPostalCode.Text, Convert.ToDecimal(cmbBoxDebetLimit.Text));

            }
            DialogResult = DialogResult.OK;
        }

        private void readyForUpdate()
        {
             _dataToShow= _logic.GetDataToUpdate(_clientIdCard);
            txtboxFirstName.Text = _dataToShow[1];
            txtBoxSurname.Text= _dataToShow[2];
            txtBoxIDCardNumber.Text= _dataToShow[3];
            txtBoxPhoneNumber.Text = _dataToShow[4];
            txtBoxEmail.Text = _dataToShow[5];
            txtBoxStreetName.Text = _dataToShow[8];
            txtHomeNumber.Text = _dataToShow[9];
            txtBoxCity.Text = _dataToShow[10];
            txtBoxPostalCode.Text = _dataToShow[11];
            labelIban.Text = _dataToShow[12];
            cmbBoxDebetLimit.Text = _dataToShow[13];
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
