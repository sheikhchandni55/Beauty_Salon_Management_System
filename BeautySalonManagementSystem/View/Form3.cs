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
    public partial class Form3 : Form
    {
        private readonly UserController userController;
        private readonly int idf3;
        public Form3(int i3)
        {
            idf3 = i3;
            userController = new UserController();

          
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new UserModel
            {
                UserID = IDtextBox1.Text,
                UserName = textBox1.Text,
                UserPass = textBox3.Text,
                UserAdd = richTextBox1.Text,
                UserRole = comboBox1.SelectedItem?.ToString(),
                UserEmail = textBox6.Text,
                UserPNo = textBox7.Text,
                UserSalary = textBox8.Text,
                UserStartDate = dateTimePicker1.Value.ToString()
            };

            if (string.IsNullOrWhiteSpace(user.UserID) || string.IsNullOrWhiteSpace(user.UserName) ||
                string.IsNullOrWhiteSpace(user.UserPass) || string.IsNullOrWhiteSpace(user.UserAdd) ||
                string.IsNullOrWhiteSpace(user.UserRole) || string.IsNullOrWhiteSpace(user.UserEmail) ||
                string.IsNullOrWhiteSpace(user.UserPNo) || string.IsNullOrWhiteSpace(user.UserSalary) ||
                string.IsNullOrWhiteSpace(user.UserStartDate))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isSuccess = userController.AddUser(user);

            if (isSuccess)
            {
                MessageBox.Show("Profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form4(idf3).Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
