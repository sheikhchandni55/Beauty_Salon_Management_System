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
    public partial class Form2 : Form
    {
        private StaffController staffController;
        private int idf2;
        public Form2(int i2)
        {
            InitializeComponent();
            idf2 = i2;
            staffController = new StaffController(panel2, idf2);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            staffController.ShowAppointment();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            staffController.ShowDashboard();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            staffController.ShowUserManagement();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            staffController.ShowCategory();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            staffController.ShowProduct();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            staffController.ShowService();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            staffController.ShowBilling();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            staffController.ShowProfile();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
