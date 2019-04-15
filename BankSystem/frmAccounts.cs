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
    public partial class frmAccounts : Form
    {
        private BSLogic _logic;
        public frmAccounts(BSLogic logic)
        {
            InitializeComponent();
            _logic = logic;
            dGVAccounts.DataSource = _logic.GetDSforAccounts();
            dGVAccounts.DataMember = "AccountsWithNames";
        }

        private void cmdManageAccount_Click(object sender, EventArgs e)
        {
            frmClientManagement manager = new frmClientManagement(_logic.GetIdCardByIban
                ( dGVAccounts.SelectedRows[0].Cells[0].Value.ToString()),_logic);
            manager.ShowDialog();
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButtonIban.Checked)
            {
                dGVAccounts.DataSource= _logic.GetFilteredAccounts("a.IBAN", textBoxFilter.Text);
                dGVAccounts.DataMember = "FilteredAccountsWithNames";
            }
            else if (radioButtonFirstName.Checked)
            {
                dGVAccounts.DataSource = _logic.GetFilteredAccounts("u.FirstName", textBoxFilter.Text);
                dGVAccounts.DataMember = "FilteredAccountsWithNames";
            }
            else if (radioButtonLastName.Checked)
            {
                dGVAccounts.DataSource = _logic.GetFilteredAccounts("u.LastName", textBoxFilter.Text);
                dGVAccounts.DataMember = "FilteredAccountsWithNames";
            }
        }

        private void dGVAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
