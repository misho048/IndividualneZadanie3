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
    public partial class frmClientManagement : Form
    {

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

      

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            using (frmAccount newForm = new frmAccount(_logic,_clientIdCard))
            {
                newForm.ShowDialog();
            }
            FillOverview();
        }

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

        private void cmdAllTransactions_Click(object sender, EventArgs e)
        {
            using (frmTransactions newForm = new frmTransactions(_logic,_clientIdCard))
            {
                newForm.ShowDialog();
            }
        }

        private void cmdNewTransaction_Click(object sender, EventArgs e)
        {
            using (frmTransaction newForm = new frmTransaction(_logic,_clientIdCard))
            {
                newForm.ShowDialog();
            }
            FillOverview();
        }

        private void cmdCloseAccount_Click(object sender, EventArgs e)
        {
            

            if (MessageBox.Show("Do you really want to close this account?", "Account Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_logic.CloseAccount(_clientIdCard))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Your balance needs to be at 0 if you want to close account!!");
                }
                }
        }

        private void buttonNewCreditCard_Click(object sender, EventArgs e)
        {
            frmNewCreditcard newCreditcard = new frmNewCreditcard(_logic,_clientIdCard,true);
            newCreditcard.ShowDialog();
            if (newCreditcard.DialogResult == DialogResult.OK)
            {
                FillCreditCardGridView();
            }

        }

        private void buttonChangePin_Click(object sender, EventArgs e)
        {
            frmNewCreditcard newCreditcard = new frmNewCreditcard(_logic, dGVCreditcards.SelectedRows[0].Cells[3].Value.ToString(), false);
            newCreditcard.ShowDialog();           
            
        }

        private void frmClientManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
