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
{
    public partial class frmTransactions : Form
    {
        BSLogic _logic;
        /// <summary>
        /// Used when viewing all transactions.
        /// </summary>
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

            //foreach (var item in dGVTransactions.Columns[2].Rows)
            //{

            //}
            
           // dGVTransactions.Columns[0].Visible = false;

        }



        /// <summary>
        /// Used when viewing selected client's transactions.
        /// </summary>
        /// <param name="clientId"></param>
        public frmTransactions(int clientId)
        {
            InitializeComponent();
        }

        private void dGVTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
