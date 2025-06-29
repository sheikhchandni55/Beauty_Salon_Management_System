using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BeautySalonManagementSystem.Model;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BeautySalonManagementSystem.Controller;



namespace BeautySalonManagementSystem.View
{
    public partial class Form1 : Form
    {
        private LoginController loginController;

        public Form1()
        {
         
            InitializeComponent();
            loginController = new LoginController();
        }



       

       private void button1_Click(object sender, EventArgs e)
        {
            string selectedRole = comboBoxRole.SelectedItem?.ToString();
            var user = new LoginModel
            {
                UserID = textBox1.Text,
                UserPass = textBox2.Text,
                UserRole = selectedRole
            };

            if (string.IsNullOrWhiteSpace(user.UserID) || string.IsNullOrWhiteSpace(user.UserPass))
            {
                MessageBox.Show("Please enter both ID and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string roleFromDB = loginController.AuthenticateUser(user);

            if (roleFromDB == null)
            {
                MessageBox.Show("Invalid ID or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (roleFromDB != user.UserRole)
            {
                MessageBox.Show("Selected role does not match your account role.", "Role Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();

            int userIdInt = int.Parse(user.UserID);
            switch (roleFromDB)
            {
                case "Customer":
                    new CustomerForm2(userIdInt).Show(); break;
                case "Staff":
                    new Form2(userIdInt).Show(); break;
                case "Admin":
                    new Form6(userIdInt).Show(); break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ForgotPassword().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp().Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.PasswordChar = '\0';
            else
                textBox2.PasswordChar = '*';
        }
    }
}

