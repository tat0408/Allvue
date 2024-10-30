using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Allvue.Model;
using Allvue.BL;
using Allvue.DL;

namespace Allvue
{
    public partial class Form1 : Form
    {
        int TotalShares = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Data data = new Data();
            List<SharesPurchases> _purchaseLots = data.GetPurchaseLots();
            dataGridView1.DataSource = _purchaseLots;
            TotalShares = _purchaseLots.Sum(x => x.Shares);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSell.Text == "" || txtSell.Text == "0")
            {
                MessageBox.Show("Enter a value in Shares to Sell field");
            }
            else
            {
                if (txtPrice.Text == ""|| txtPrice.Text == "0")
                {
                    MessageBox.Show("Enter a value in Sale price to Sell");}
                else
                {
                    if (Convert.ToInt16(txtSell.Text) > TotalShares)
                    {
                        MessageBox.Show("Shares to Sell cannot be greater than " + TotalShares);
                    }
                    else
                    {

                        Calculator calculator = new Calculator();


                        int sharesToSell = int.Parse(txtSell.Text);
                        decimal salePricePerShare = decimal.Parse(txtPrice.Text);

                        var result = calculator.CalculateFIFO(sharesToSell, salePricePerShare);

                        lbRemaining.Text = result.remainingShares.ToString();
                        lbCostSold.Text = result.soldCostBasis.ToString();
                        lbCostRemaining.Text = result.remainingCostBasis.ToString();
                        lbProfit.Text = result.profit.ToString();
                    }
                }
            }


        }

        private void txtSell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Discard the character
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys, digits, and a single decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
