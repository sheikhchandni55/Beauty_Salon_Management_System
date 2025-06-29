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
    public partial class Form7 : Form
    {
        private readonly int idf7;
        private readonly ProController proController;
        public Form7(int i7)
        {
            idf7 = i7;
            proController = new ProController();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new ProModel
            {
                UserRole = comboBox1.SelectedItem?.ToString(),
                UserID = IDtextBox1.Text,
                UserName = textBox1.Text,
                UserPass = textBox2.Text,
                UserAdd = richTextBox1.Text,
                UserEmail = textBox3.Text,  
                UserPNo = textBox4.Text,
                UserStartDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") // better formatting
            };

            if (string.IsNullOrWhiteSpace(user.UserID) || string.IsNullOrWhiteSpace(user.UserName) ||
                string.IsNullOrWhiteSpace(user.UserPass) || string.IsNullOrWhiteSpace(user.UserAdd) ||
                string.IsNullOrWhiteSpace(user.UserEmail) || string.IsNullOrWhiteSpace(user.UserPNo) || string.IsNullOrWhiteSpace(user.UserRole) ||
                string.IsNullOrWhiteSpace(user.UserStartDate))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = proController.SaveProfile(user);
            if (success)
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
            Form6 f6 = new Form6(idf7);
            f6.Show();
        }
    }
}
