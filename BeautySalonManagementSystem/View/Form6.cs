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
    public partial class Form6 : Form
    {
        private readonly int idf6;
        private AdminController controller;

        public Form6(int i6)
        {
            InitializeComponent();
            idf6 = i6;
            controller = new AdminController(panel2, idf6);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.ShowDashboard();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.ShowUserForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.ShowCategoryForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            controller.ShowProductForm();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            controller.ShowBillingForm();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            controller.ShowCreateUserForm();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            controller.ShowProfileForm();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f11 = new Form1();
            f11.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}