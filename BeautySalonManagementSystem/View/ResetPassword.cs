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
    public partial class ResetPassword : Form
    {
        private readonly int userId;
        private readonly PasswordResetController controller;

        public ResetPassword(int i)
        {
            InitializeComponent();
            userId = i;
            controller = new PasswordResetController();
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

        private void button1_Click(object sender, EventArgs e)
        {
            var model = new PasswordResetModel
            {
                UserID = userId,
                NewPassword = textBox2.Text,
                ConfirmPassword = textBox1.Text
            };

            if (!controller.ValidatePasswords(model.NewPassword, model.ConfirmPassword, out string validationMessage))
            {
                MessageBox.Show(validationMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // (Optional: You can verify old password if you had a "Current Password" field.)

            bool result = controller.UpdatePassword(model);

            if (result)
            {
                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new Form1().Show();
            }
            else
            {
                MessageBox.Show("Failed to change the password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
