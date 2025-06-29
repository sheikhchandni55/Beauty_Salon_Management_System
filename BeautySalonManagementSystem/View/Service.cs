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
    public partial class Service : Form
    {
        private readonly int id;
        private readonly ServiceCon controller;

        public Service(int i)
        {
            InitializeComponent();        

            id = i;
            controller = new ServiceCon();
            RefreshGrid();             
        }
        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        private void RefreshGrid()
        {
            if (dataGridView1 != null)
                dataGridView1.DataSource = controller.GetAllServices();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2(id).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string serviceID = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(serviceID))
            {
                MessageBox.Show("Enter a ServiceID to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Confirm deletion?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes && controller.DeleteService(serviceID))
            {
                MessageBox.Show("Deleted.");
                RefreshGrid();
            }
            else
                MessageBox.Show("Deletion failed.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var service = new ServiceMod
            {
                ServiceID = textBox1.Text.Trim(),
                ServiceName = textBox2.Text.Trim()
            };

            if (controller.UpdateService(service))
            {
                MessageBox.Show("Updated successfully.");
                RefreshGrid();
            }
            else
                MessageBox.Show("Update failed.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var service = new ServiceMod
            {
                ServiceID = textBox1.Text.Trim(),
                ServiceName = textBox2.Text.Trim()
            };

            if (string.IsNullOrWhiteSpace(service.ServiceID) || string.IsNullOrWhiteSpace(service.ServiceName))
            {
                MessageBox.Show("All fields required.");
                return;
            }

            if (controller.AddService(service))
            {
                MessageBox.Show("Added successfully.");
                RefreshGrid();
                ClearFields();
            }
            else
                MessageBox.Show("Failed to add.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string searchValue = textBox5.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Enter a search term.", "Validation Error");
                return;
            }

            DataTable result = controller.SearchServices(searchValue);
            dataGridView1.DataSource = result;

            if (result.Rows.Count == 0)
                MessageBox.Show("No matching rows found.");
        }
    }
}
