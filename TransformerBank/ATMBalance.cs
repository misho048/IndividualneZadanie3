using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformerBank
{
    /// <summary>
    /// this class is just to show account balance
    /// and some info
    /// </summary>
    public partial class ATMBalance : Form
    {
        /// <summary>
        /// saves logic
        /// login information
        /// 
        /// </summary>
        private ATMLogic _logic;
        private string _login;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="login"></param>
        public ATMBalance(ATMLogic logic,string login)
        {
            _logic = logic;
            _login = login;
            InitializeComponent();
            FillLabels();

            
        }
        /// <summary>
        /// returns from the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// methods to fill the labels and show saome data
        /// </summary>
        private void FillLabels()
        {
           
            labelIBAN.Text = _logic.GetBalance(_login).IBAN;
            labelBalance.Text= _logic.GetBalance(_login).Balance.ToString();
            labelDebtLimit.Text = _logic.GetBalance(_login).DebtLimit.ToString();
            labelName.Text = _logic.OwnerNameByCardNumber(_login);
          
        }

      
    }
}
