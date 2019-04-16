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
/// this form is here for looking at accounts data and to filter them
/// </summary>
    public partial class frmAccounts : Form
    {
        /// <summary>
        /// we need logic here as alaways
        /// </summary>
        private BSLogic _logic;
        /// <summary>
        /// constructor
        /// datagridview filled with datasource from logic
        /// </summary>
        /// <param name="logic"></param>
        public frmAccounts(BSLogic logic)
        {
            InitializeComponent();
            _logic = logic;
            dGVAccounts.DataSource = _logic.GetDSforAccounts();
            dGVAccounts.DataMember = "AccountsWithNames";
        }

        /// <summary>
        /// jumps into client manager form
        /// with the selected index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdManageAccount_Click(object sender, EventArgs e)
        {
            frmClientManagement manager = new frmClientManagement(_logic.GetIdCardByIban
                ( dGVAccounts.SelectedRows[0].Cells[0].Value.ToString()),_logic);
            manager.ShowDialog();
        }

    

        /// <summary>
        /// button for filtering result based on which radiobtton is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

       
    }
}
