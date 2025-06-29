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
    public partial class SignUp : Form
    {
        private SignUpController controller;
        public SignUp()
        {
            InitializeComponent();
            controller = new SignUpController();

            comboBoxRole.DataSource = new string[] { "Admin", "Employee", "Customer" };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new SignUpUser
            {
                UserID = IDtextBox1.Text,
                UserName = textBox4.Text,
                UserPass = textBox3.Text,
                UserAdd = richTextBox1.Text,
                UserRole = comboBoxRole.SelectedItem?.ToString(),
                UserEmail = textBox1.Text,
                UserPNo = textBox2.Text,
                UserSalary = "0", // default salary
                UserStartDate = dateTimePicker1.Value.ToString()
            };

            if (string.IsNullOrWhiteSpace(user.UserID) ||
                string.IsNullOrWhiteSpace(user.UserName) ||
                string.IsNullOrWhiteSpace(user.UserPass) ||
                string.IsNullOrWhiteSpace(user.UserAdd) ||
                string.IsNullOrWhiteSpace(user.UserRole) ||
                string.IsNullOrWhiteSpace(user.UserEmail) ||
                string.IsNullOrWhiteSpace(user.UserPNo) ||
                string.IsNullOrWhiteSpace(user.UserSalary) ||
                string.IsNullOrWhiteSpace(user.UserStartDate))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (controller.CreateUser(user, out string errorMsg))
            {
                MessageBox.Show("Profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new Form1().Show();
            }
            else
            {
                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
