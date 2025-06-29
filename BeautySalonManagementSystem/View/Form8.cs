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
    public partial class Form8 : Form
    {
        private int idf8;
        private CusUpdateController controller;
        public Form8(int i8)
        {
     
            InitializeComponent();
            idf8 = i8;
            controller = new CusUpdateController();

            comboBox1.DataSource = new string[] { "Admin", "Employee", "Customer" };
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CusUpdate user = new CusUpdate
            {
                UserID = IDtextBox1.Text.Trim(),
                UserName = textBox1.Text.Trim(),
                UserPass = textBox3.Text.Trim(),
                UserAdd = richTextBox1.Text.Trim(),
                UserRole = comboBox1.SelectedItem?.ToString(),
                UserEmail = textBox6.Text.Trim(),
                UserPNo = textBox7.Text.Trim()
            };

            // Validation
            if (string.IsNullOrWhiteSpace(user.UserID) || string.IsNullOrWhiteSpace(user.UserName) ||
                string.IsNullOrWhiteSpace(user.UserPass) || string.IsNullOrWhiteSpace(user.UserAdd) ||
                string.IsNullOrWhiteSpace(user.UserRole) || string.IsNullOrWhiteSpace(user.UserEmail) ||
                string.IsNullOrWhiteSpace(user.UserPNo))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = controller.CreateUser(user);

            if (success)
            {
                MessageBox.Show("Profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to create profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
