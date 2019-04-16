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
/// Main form, first loaded when app start
/// </summary>
    public partial class frmMain : Form
    {
        /// <summary>
        /// instance of Logic is created here 
        /// </summary>
        private BSLogic _logic = new BSLogic();

        /// <summary>
        /// Constructor
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// find client button, if no client is sleected nothing will happend
        /// otherwise we weill be send to a client manager 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdFindClient_Click(object sender, EventArgs e)
        {
            
            if (!comboBox1.SelectedIndex.Equals(-1))
            {

                using (frmClientManagement newForm = new frmClientManagement(comboBox1.Text.Split(' ')[0], _logic))
                {
                    newForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// form to create new account
        /// will start here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNewAccount_Click(object sender, EventArgs e)
        {
            using (frmAccount newForm = new frmAccount(_logic))
            {

                newForm.ShowDialog();
            }
        }

        /// <summary>
        /// jumps into new form with all accounts 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAllAccounts_Click(object sender, EventArgs e)
        {
            using (frmAccounts newForm = new frmAccounts(_logic))
            {
                newForm.ShowDialog();
            }
        }

        /// <summary>
        /// jumps into new form with all transactions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAllTransactions_Click(object sender, EventArgs e)
        {
            using (frmTransactions newForm = new frmTransactions(_logic))
            {
                newForm.ShowDialog();
            }
        }


        /// <summary>
        /// fill comboo when you scroll down based on entered information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (var item in _logic.FilterUsersByIDCard(comboBox1.Text))
            {

                comboBox1.Items.Add($"{item.IDCardName} {item.LastName} {item.FirstName}");
            }
        }

        /// <summary>
        /// button for closing program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// next buttons are for manager overview
        /// </summary>
 
        private void buttonTopClients_Click(object sender, EventArgs e)
        {
            dGVManagerOverview.DataSource = _logic.GetTopClients();
            dGVManagerOverview.DataMember = "TopTenClients";
        }

        private void buttonBankAssets_Click(object sender, EventArgs e)
        {
            dGVManagerOverview.DataSource = _logic.GetBankAssets();
            dGVManagerOverview.DataMember = "BankAssets";
        }

        private void buttonNumberAccounts_Click(object sender, EventArgs e)
        {
            dGVManagerOverview.DataSource = _logic.GetAccountsCount();
            dGVManagerOverview.DataMember = "AccountCount";
        }

        private void buttonnumberAccountsIn_Click(object sender, EventArgs e)
        {
            dGVManagerOverview.DataSource = _logic.GetAccountsCountForMonth();
            dGVManagerOverview.DataMember = "AccountCountForMonth";
        }

        private void buttonDemography_Click(object sender, EventArgs e)
        {
            dGVManagerOverview.DataSource = _logic.GetDemography();
            dGVManagerOverview.DataMember = "Demography";
        }
    }
}
