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
    public partial class Form5 : Form
    {
        private readonly int id;
        private readonly ChangePasswordController controller;
        public Form5(int i)
        {
            id = i;
            controller = new ChangePasswordController();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var model = new ChangePasswordModel
            {
                UserID = id,
                CurrentPassword = textBox3.Text,
                NewPassword = textBox1.Text,
                ConfirmPassword = textBox2.Text
            };

            if (!controller.ValidateInput(model, out string error))
            {
                MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!controller.VerifyCurrentPassword(model.UserID, model.CurrentPassword))
            {
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool updated = controller.UpdatePassword(model.UserID, model.NewPassword);
            if (updated)
            {
                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new Form1().Show(); // Go back to login
            }
            else
            {
                MessageBox.Show("Failed to change password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form4(id).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
