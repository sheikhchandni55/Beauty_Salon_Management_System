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
    public partial class CustomerForm2 : Form
    {
        private readonly CustomerController customerController;
        private readonly CustomerModel customerModel;

        public CustomerForm2(int i2)
        {
            InitializeComponent();

            customerModel = new CustomerModel(i2);
            customerController = new CustomerController(panel2, customerModel);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            customerController.LoadAppointments();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            customerController.LoadDashboard();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            customerController.LoadServices();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            customerController.LoadCategories();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            customerController.LoadProducts();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            customerController.ShowPaymentForm();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show(); // Go back to login
        }

        private void CustomerForm2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            customerController.ShowForm8();
        }
    }
}

