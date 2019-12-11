using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vending_Machine
{
    public partial class vendingForm : Form
    {
        int chipsInv = 10;
        int sodaInv = 10;
        int candyInv = 10;
        double moneyIn;
        double moneyLeft = 0;

        public vendingForm()
        {
            InitializeComponent();
        }
        Vend v = new Vend();
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("A new law has added a tax to vending machines in an attempt to combat obesity in a similar way to how the government combats tobacco use. As such, you can't buy an item unless you have at least one cent above it's actual value as the remaining coins, this is because as of leaving, these remaining coins will be given to the machine. Basically, you can't go to $0.00, and if you attempt to, it will be treated the same as if you didn't have enough money. Thanks for your patience!", "New Tax", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            label6.Text = label6.Text + chipsInv;
            label7.Text = label7.Text + sodaInv;
            label8.Text = label8.Text + candyInv;
            label1.Text = "Total input: " + moneyIn.ToString("C2");
            label5.Text = "Currently in Machine: $0.00";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            moneyIn += 1;
            moneyLeft += 1;
            v.Add(1);
            label1.Text = "Total input: " + moneyIn.ToString("C2");
            label5.Text = "Currently in Machine: " + v.getAmount();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            moneyIn += 0.25;
            moneyLeft += 0.25;
            v.Add(0.25);
            label1.Text = "Total input: " + moneyIn.ToString("C2");
            label5.Text = "Currently in Machine: " + v.getAmount();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            moneyIn += 5;
            moneyLeft += 5;
            v.Add(5);
            label1.Text = "Total input: " + moneyIn.ToString("C2");
            label5.Text = "Currently in Machine: " + v.getAmount();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            moneyIn += 0.1;
            moneyLeft += 0.1;
            v.Add(.1);
            label1.Text = "Total input: " + moneyIn.ToString("C2");
            label5.Text = "Currently in Machine: " + v.getAmount();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            moneyIn += 0.05;
            moneyLeft += 0.05;
            v.Add(.05);
            label1.Text = "Total input: " + moneyIn.ToString("C2");
            label5.Text = "Currently in Machine: " + v.getAmount();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            v.buy(.5);
            label5.Text = "Currently in Machine: " + v.getAmount();
            if (moneyLeft > 0.5)
            {
            moneyLeft -= .5;
                if (sodaInv > 0)
                {
                    sodaInv = sodaInv - 1;
                    label7.Text = "Total Inventory: " + sodaInv;
                }
                else
                {
                    moneyLeft += .5;
                    v.Add(.5);
                    MessageBox.Show("Sorry, this item is out of stock");
                }
            }
            else
            {
                MessageBox.Show("Please enter more money to buy this item");
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            v.buy(.75);
            label5.Text = "Currently in Machine: " + v.getAmount();
            if (moneyLeft > 0.75)
            {
            moneyLeft -= .75;
                if (chipsInv > 0)
                {
                    chipsInv = chipsInv - 1;
                    label6.Text = "Total Inventory: " + chipsInv;
                }
                else
                {
                    moneyLeft += .75;
                    v.Add(.75);
                    MessageBox.Show("Sorry, this item is out of stock");
                }
            }
            else
            {
                MessageBox.Show("Please enter more money to buy this item");
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            v.buy(1.5);
            label5.Text = "Currently in Machine: " + v.getAmount();
            if (moneyLeft > 1.5)
            {
            moneyLeft -= 1.5;
                if (candyInv > 0)
                {
                    candyInv = candyInv - 1;
                    label8.Text = "Total Inventory: " + candyInv;
                }
                else
                {
                    moneyLeft += 1.5;
                    v.Add(1.5);
                    MessageBox.Show("Sorry, this item is out of stock");
                }
            }
            else
            {
                MessageBox.Show("Please enter more money to buy this item");
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            double moneyBack = (moneyLeft + (moneyIn - moneyLeft));
            v.Add(moneyBack);
            moneyLeft = moneyBack;
            sodaInv = 10;
            chipsInv = 10;
            candyInv = 10;
            label6.Text = "Total Inventory: " + chipsInv;
            label7.Text = "Total Inventory: " + sodaInv;
            label8.Text = "Total Inventory: " + candyInv;
            label5.Text = "Currently in the Machine: " + moneyBack.ToString("C2");
            MessageBox.Show("All of your money has been returned, but the items you bought have been returned as well.");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Total input: " + moneyIn.ToString("C2");
            label5.Text = "Currently in the Machine: " + moneyLeft.ToString("C2");
        }
    }
}
