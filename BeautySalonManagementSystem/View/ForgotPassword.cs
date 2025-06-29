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
    public partial class ForgotPassword : Form
    {
        private ForgotPasswordController forgotPasswordController;
        public ForgotPassword()
        {
            forgotPasswordController = new ForgotPasswordController();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userId = textBox1.Text.Trim();
            string phoneNo = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(phoneNo))
            {
                MessageBox.Show("User ID and Phone Number are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var model = new ForgotPasswordModel(userId, phoneNo);
            bool isVerified = forgotPasswordController.VerifyUser(model);

            if (isVerified)
            {
                MessageBox.Show("Details verified successfully. You can now reset your password.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                ResetPassword resetForm = new ResetPassword(int.Parse(userId));
                resetForm.Show();
            }
            else
            {
                MessageBox.Show("User ID or Phone Number is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
