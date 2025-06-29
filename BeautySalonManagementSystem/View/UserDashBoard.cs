using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalonManagementSystem.Model;
using System.Windows.Forms;
using BeautySalonManagementSystem.Controller;
namespace BeautySalonManagementSystem.View
{
    public partial class UserDashBoard : Form
    {
        private readonly UserDashBoardCon controller;
        public UserDashBoard()
        {
            InitializeComponent();
            controller = new UserDashBoardCon();
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            dataGridView1.DataSource = controller.GetAppointmentData();
            dataGridView2.DataSource = controller.GetBillingData();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            try
            {
                UserDashBoardMod model = controller.GetTotalStaff();
                label3.Text = model.TotalStaff.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable searchResult = controller.SearchBillingByCustomerID(searchValue);
            dataGridView2.DataSource = searchResult;

            if (searchResult.Rows.Count == 0)
            {
                MessageBox.Show("No matching rows found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

