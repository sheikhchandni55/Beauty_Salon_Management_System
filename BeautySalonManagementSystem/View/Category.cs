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
    public partial class Category : Form
    {
        private readonly int id;
        private readonly CategoryController controller;

        public Category(int i)
        {
            InitializeComponent();
            id = i;
            controller = new CategoryController();
            FillDataGridView();
        }

        private void FillDataGridView()
        {
            dataGridView1.DataSource = controller.GetAllCategories();
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            string searchValue = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridView1.DataSource = controller.SearchServices(searchValue);

            if (((System.Data.DataTable)dataGridView1.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("No matching rows found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var category = new CategoryModel
            {
                CategoryID = textBox1.Text.Trim(),
                CategoryName = textBox2.Text.Trim(),
                CategoryPrice = textBox3.Text.Trim(),
                ServiceID = textBox4.Text.Trim()
            };

            if (string.IsNullOrWhiteSpace(category.CategoryID) ||
                string.IsNullOrWhiteSpace(category.CategoryName) ||
                string.IsNullOrWhiteSpace(category.CategoryPrice) ||
                string.IsNullOrWhiteSpace(category.ServiceID))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = controller.InsertCategory(category);
            if (success)
            {
                MessageBox.Show("Record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDataGridView();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to add the record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var category = new CategoryModel
            {
                CategoryID = textBox1.Text.Trim(),
                CategoryName = textBox2.Text.Trim(),
                CategoryPrice = textBox3.Text.Trim(),
                ServiceID = textBox4.Text.Trim()
            };

            if (string.IsNullOrWhiteSpace(category.CategoryID) ||
                string.IsNullOrWhiteSpace(category.CategoryName) ||
                string.IsNullOrWhiteSpace(category.CategoryPrice) ||
                string.IsNullOrWhiteSpace(category.ServiceID))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = controller.UpdateCategory(category);
            if (success)
            {
                MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDataGridView();
            }
            else
            {
                MessageBox.Show("No record was updated. Please check the CategoryID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string categoryId = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(categoryId))
            {
                MessageBox.Show("Please enter a CategoryID to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this record?",
                                         "Confirm Deletion",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = controller.DeleteCategory(categoryId);
                if (success)
                {
                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDataGridView();
                }
                else
                {
                    MessageBox.Show("No record found with the provided CategoryID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}