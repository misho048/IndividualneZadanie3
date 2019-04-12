using Data.Repositories;
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
            
        }

        /// <summary>
        /// Used when viewing selected client's transactions.
        /// </summary>
        /// <param name="clientId"></param>
        public frmTransactions(int clientId)
        {
            InitializeComponent();
        }
    }
}
