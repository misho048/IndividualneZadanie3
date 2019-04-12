
using System;
using System.Windows.Forms;

namespace TransformerBank
{
    public partial class frmMain : Form
    {
        private int count = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Data.Repositories.CardsRepository cards = new Data.Repositories.CardsRepository();
            if ((numericTxtBoxLogin.Text.ToString().Length == 0) || (numericTxtBoxPin.Text.ToString().Length == 0))
            {
                MessageBox.Show("Enter login informations");
            }
            else
            {
                if (cards.CheckPin(numericTxtBoxLogin.Text, Convert.ToInt32(numericTxtBoxPin.Text)))
                {

                    FrmATMChoosing choosing = new FrmATMChoosing(numericTxtBoxLogin.Text);
                    choosing.ShowDialog();

                }
                else
                {
                    count++;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
