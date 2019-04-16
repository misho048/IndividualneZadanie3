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
{/// <summary>
/// form for creating and editing USer informations with some 
/// debtlimit
/// </summary>
    public partial class frmAccount : Form
    {
        /// <summary>
        /// fields logic, clientIDCard
        /// isUpdate shows if we are creating new user or updating old one
        /// if we are updating we aleso need old data to show
        /// </summary>
        private BSLogic _logic;
        private string _clientIdCard;
        private bool _isUpdate;
        private string[] _dataToShow;

        /// <summary>
        /// contructior for updating
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="clientIdCard"></param>
        public frmAccount(BSLogic logic, string clientIdCard)
        {
            _logic = logic;
            InitializeComponent();
            _clientIdCard = clientIdCard;
            ReadyForUpdate();
            _isUpdate = true;
          


        }
        /// <summary>
        /// Used when adding new account.
        /// </summary>
        public frmAccount(BSLogic logic)
        {
            _logic = logic;
            InitializeComponent();
            label1ibangen.Text = _logic.GenerateIBAN();
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

     
        /// <summary>
        /// cancel button no changes saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// saves data in textboxes to the field
        /// and call update/create user method from logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                _dataToShow[12] = label1ibangen.Text;
                _dataToShow[13] = cmbBoxDebetLimit.Text;                
                _logic.UpdateUserInfo(_dataToShow);
               

            }
            else
            {
                _logic.CreateUser(txtboxFirstName.Text, txtBoxSurname.Text, txtBoxIDCardNumber.Text,
                    txtBoxPhoneNumber.Text, txtBoxEmail.Text, txtBoxStreetName.Text, Convert.ToInt32(txtHomeNumber.Text),
                    txtBoxCity.Text, txtBoxPostalCode.Text, Convert.ToDecimal(cmbBoxDebetLimit.Text), label1ibangen.Text);
                
              
            }
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// loads some data into textboxes
        /// so we can see old data while updating 
        /// </summary>
        private void ReadyForUpdate()
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
            label1ibangen.Text = _dataToShow[12];
            cmbBoxDebetLimit.Text = _dataToShow[13];
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
