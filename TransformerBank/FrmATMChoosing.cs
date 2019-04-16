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
{/// <summary>
/// opening form for ATM after succesful Login
/// </summary>
    public partial class FrmATMChoosing : Form
    {
        /// <summary>
        /// we are getting logic from MainWindow
        /// and the login card information
        /// </summary>
        private ATMLogic _logic;
        private string _cardNumber;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="logic"></param>
        public FrmATMChoosing(string cardNumber,ATMLogic logic)
        {
            _logic = logic;
            _cardNumber = cardNumber;
            InitializeComponent();
        }
        
        /// <summary>
        /// this button sends us to the next dialog, and checks if the dialog result 
        /// is OK if yes transaction was done and close this form and return to the  
        /// main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ATMwithdraw atmFormwithdraw = new ATMwithdraw(_cardNumber, _logic);
            atmFormwithdraw.ShowDialog();
            if (atmFormwithdraw.DialogResult==DialogResult.OK)
            {
                MessageBox.Show("Goodbye and Have a nice day");
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// button to send us to the Account information Panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnBalance_Click(object sender, EventArgs e)
        {
            ATMBalance balance = new ATMBalance(_logic, _cardNumber);
            balance.ShowDialog();
        }

        /// <summary>
        /// button for a cancel, return from current form to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

    
    }
}
