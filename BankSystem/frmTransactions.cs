using Data.Repositories;
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
/// form to look at all transactions
/// </summary>
    public partial class frmTransactions : Form
    {/// <summary>
    /// using logic here
    /// *this is not a church xD*
    /// </summary>
        BSLogic _logic;
    /// <summary>
    /// constructor
    /// initialiying components and filling datagridview
    /// hiding and editing unnecessary data 
    /// </summary>
    /// <param name="logic"></param>
        public frmTransactions(BSLogic logic)
        {
            InitializeComponent();

            _logic = logic;          

            dGVTransactions.DataSource = _logic.GetTransactions();

            dGVTransactions.Columns[0].Visible = false;
         

            foreach (DataGridViewRow Item in dGVTransactions.Rows)
            {
                
                Item.Cells[2].Value = (Item.Cells[1].Value.Equals(Item.Cells[2].Value)) ? "Bank Transaction" :
                    _logic.GetIbanbyAccountID(Convert.ToInt32(Item.Cells[2].Value));

                Item.Cells[1].Value = _logic.GetIbanbyAccountID(Convert.ToInt32(Item.Cells[1].Value));

            }

        }

        /// <summary>
        /// this construcotr is called when we want to see all transactions done by User
        /// also hiding and editing unnecessary data
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="clientIdCard"></param>

        public frmTransactions(BSLogic logic,string clientIdCard)
        {
            InitializeComponent();
         
            _logic = logic;         
            dGVTransactions.DataSource = _logic.GetTransactionsByIdCard(clientIdCard);
            dGVTransactions.Columns[0].Visible = false;
            dGVTransactions.Columns[1].Visible = false;
            

            foreach (DataGridViewRow Item in dGVTransactions.Rows)
            {

                Item.Cells[2].Value = (Item.Cells[1].Value.Equals(Item.Cells[2].Value)) ? "Bank Transaction" : 
                    _logic.GetIbanbyAccountID(Convert.ToInt32(Item.Cells[2].Value));
            }

           

        }
                        

     
    }
}
