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
    /// <summary>
    /// form to manage clients
    /// </summary>
    public partial class frmClientManagement : Form
    {
        /// <summary>
        /// we need logic here and client id card information from previous forms
        /// </summary>
        private BSLogic _logic;
        private string _clientIdCard;

        /// <summary>
        /// Used when viewing/updating existing client.
        /// </summary>
        /// <param name="clientIdCard"></param>
        public frmClientManagement(string  clientIdCard, BSLogic logic)
        {
            _logic = logic;
            _clientIdCard = clientIdCard;
            
            InitializeComponent();
            FillCreditCardGridView();
            FillOverview();
        }

      
/// <summary>
/// goes into update form and updates user info
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            using (frmAccount newForm = new frmAccount(_logic,_clientIdCard))
            {
                newForm.ShowDialog();
            }
            FillOverview();
        }
        /// <summary>
        /// fill data grid view  and hide / edit unneccesary data
        /// </summary>

        private void FillCreditCardGridView()
        {
            dGVCreditcards.DataSource = null;
            dGVCreditcards.DataSource = _logic.GetCreditcardsByIDCard(_clientIdCard);
            dGVCreditcards.Columns[0].Visible = false;
            dGVCreditcards.Columns[2].Visible = false;
            dGVCreditcards.Columns[4].Visible = false;
            dGVCreditcards.ReadOnly = true;
            dGVCreditcards.MultiSelect = false;
        }

        /// <summary>
        /// fill user overview
        /// </summary>

        private void FillOverview() {
            textBoxName.Text = _logic.GetDataToUpdate(_clientIdCard)[1];
            textBoxSurname.Text = _logic.GetDataToUpdate(_clientIdCard)[2];
            textBoxIDCardNumber.Text = _logic.GetDataToUpdate(_clientIdCard)[3];
            textBoxPhoneNumber.Text = _logic.GetDataToUpdate(_clientIdCard)[4];
            textBoxCity.Text = _logic.GetDataToUpdate(_clientIdCard)[9];
            textBoxPostalCode.Text =_logic.GetDataToUpdate(_clientIdCard)[10];
            textBoxIban.Text = _logic.GetDataToUpdate(_clientIdCard)[12];
            textBoxBalance.Text = _logic.GetBalancebyClientIdCard(_clientIdCard).ToString();
            textBoxDebtLimit.Text = _logic.GetDataToUpdate(_clientIdCard)[13];
        }       

        /// <summary>
        /// shows new form with all transactions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cmdAllTransactions_Click(object sender, EventArgs e)
        {
            using (frmTransactions newForm = new frmTransactions(_logic,_clientIdCard))
            {
                newForm.ShowDialog();
            }
        }

        /// <summary>
        /// open form where we are creating a new transaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNewTransaction_Click(object sender, EventArgs e)
        {
            using (frmTransaction newForm = new frmTransaction(_logic,_clientIdCard))
            {
                newForm.ShowDialog();
            }
            FillOverview();
        }

        /// <summary>
        /// chcecks if its possible and if yes then close account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCloseAccount_Click(object sender, EventArgs e)
        {
            

            if (MessageBox.Show("Do you really want to close this account?", "Account Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_logic.CloseAccount(_clientIdCard) && !_logic.IsThereAnyCards(_clientIdCard))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Your balance needs to be at 0 if you want to close account, and you cant have any active credit cards!!");
                    
                }
                }
        }

        /// <summary>
        /// create form for a new creditcrad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonNewCreditCard_Click(object sender, EventArgs e)
        {
            frmNewCreditcard newCreditcard = new frmNewCreditcard(_logic,_clientIdCard,true);
            newCreditcard.ShowDialog();
            if (newCreditcard.DialogResult == DialogResult.OK)
            {
                FillCreditCardGridView();
            }

        }

        /// <summary>
        /// send us to the form to change pin to a credit card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonChangePin_Click(object sender, EventArgs e)
        {
            frmNewCreditcard newCreditcard = new frmNewCreditcard(_logic, dGVCreditcards.SelectedRows[0].Cells[3].Value.ToString(), false);
            newCreditcard.ShowDialog();           
            
        }

        /// <summary>
        /// button to block/unblock credit card
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonBlockUnblock_Click(object sender, EventArgs e)
        {

           _logic.BlockUnblockCard(dGVCreditcards.SelectedRows[0].Cells[3].Value.ToString());
            FillCreditCardGridView();
        }

        private void textBoxDebtLimit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
