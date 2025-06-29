using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautySalonManagementSystem.Controller;
using BeautySalonManagementSystem.Model;

namespace BeautySalonManagementSystem.View
{
    public partial class Payment : Form
    {
        private int idf2;
        private readonly PaymentCon controller;

        public Payment (int i2)
        {
            idf2 = i2;
         
            controller = new PaymentCon();
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CustomerForm2(idf2).Show();
        }

        private void mobileBankingBtn_Click(object sender, EventArgs e)
        {
            var payment = new PaymentMod
            {
                PhoneNo = txtPhone.Text,
                Pin = txtPin.Text
            };

            if (controller.ValidateMobileBankingPayment(payment))
            {
                MessageBox.Show("Payment Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid Mobile Banking Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cardMakePaymentbtn_Click(object sender, EventArgs e)
        {
            var payment = new PaymentMod
            {
                CardHolderName = txtCardHolderName.Text,
                CardNumber = txtCardNumber.Text
            };

            if (controller.VerifyCardPayment(payment))
            {
                MessageBox.Show("Payment Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid Card Details. Payment Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cardBtn_Click(object sender, EventArgs e)
        {
            panelCard.Visible = true;
            mobileBankingPanel.Visible = false;
        }

        private void rocketBtn_Click(object sender, EventArgs e)
        {
            panelCard.Visible = false;
            mobileBankingPanel.Visible = true;
        }

        private void nagadBtn_Click(object sender, EventArgs e)
        {
            panelCard.Visible = false;
            mobileBankingPanel.Visible = true;
        }

        private void bkashBtn_Click(object sender, EventArgs e)
        {
            panelCard.Visible = false;
            mobileBankingPanel.Visible = true;
        }
    }
}
    
