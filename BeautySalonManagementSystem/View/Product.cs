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
    public partial class Product : Form
    {
        private readonly int id;
        private readonly ProductController controller;

        public Product(int i)
        {
            InitializeComponent();
            id = i;
            controller = new ProductController();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridView1.DataSource = controller.GetAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string searchValue = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            DataTable result = controller.SearchProduct(searchValue);
            dataGridView1.DataSource = result;

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("No matching rows found.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var product = new ProductModel
            {
                ProductID = textBox1.Text.Trim(),
                ProductName = textBox2.Text.Trim(),
                ProductPrice = textBox3.Text.Trim(),
                ProductExpDate = dateTimePicker1.Value.ToString("dd/MM/yyyy")
            };

            if (string.IsNullOrWhiteSpace(product.ProductID) || string.IsNullOrWhiteSpace(product.ProductName) || string.IsNullOrWhiteSpace(product.ProductPrice))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (controller.AddProduct(product))
            {
                MessageBox.Show("Product added successfully.");
                LoadData();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to add product.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var product = new ProductModel
            {
                ProductID = textBox1.Text.Trim(),
                ProductName = textBox2.Text.Trim(),
                ProductPrice = textBox3.Text.Trim(),
                ProductExpDate = dateTimePicker1.Value.ToString("dd/MM/yyyy")
            };

            if (controller.UpdateProduct(product))
            {
                MessageBox.Show("Product updated.");
                LoadData();
            }
            else
            {
                MessageBox.Show("Update failed. Check Product ID.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string productId = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(productId))
            {
                MessageBox.Show("Please enter a Product ID.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (controller.DeleteProduct(productId))
                {
                    MessageBox.Show("Deleted successfully.");
                    LoadData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Delete failed. Check Product ID.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form6 f6 = new Form6(id);
            f6.Show();
        }
    }
}