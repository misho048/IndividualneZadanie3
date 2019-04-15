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
    public partial class frmMain : Form
    {
        private BSLogic _logic = new BSLogic();
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdFindClient_Click(object sender, EventArgs e)
        {
            
            
            using (frmClientManagement newForm = new frmClientManagement( comboBox1.Text.Split(' ')[0], _logic))
            {
                newForm.ShowDialog();
            }
        }

        private void cmdNewAccount_Click(object sender, EventArgs e)
        {
            using (frmAccount newForm = new frmAccount(_logic))
            {

                newForm.ShowDialog();
            }
        }

        private void cmdAllAccounts_Click(object sender, EventArgs e)
        {
            using (frmAccounts newForm = new frmAccounts(_logic))
            {
                newForm.ShowDialog();
            }
        }

        private void cmdAllTransactions_Click(object sender, EventArgs e)
        {
            using (frmTransactions newForm = new frmTransactions(_logic))
            {
                newForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
        }

        private void txtBoxFindClient_TextChanged(object sender, EventArgs e)
        {

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            
         

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (var item in _logic.FilterUsersByIDCard(comboBox1.Text))
            {

                comboBox1.Items.Add($"{item.IDCardName} {item.LastName} {item.FirstName}");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

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
