using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautySalonManagementSystem.Model;
using BeautySalonManagementSystem.Controller;
namespace BeautySalonManagementSystem.View
{
    public partial class Billing : Form
    {
        private BillingController controller = new BillingController();
        private DataTable addedProductsTable = new DataTable();
        private int userId;

        public Billing(int id)
        {
            InitializeComponent();
            userId = id;
            LoadData();
            InitializeAddedProductsTable();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = controller.GetAllProducts();
            dataGridView2.DataSource = controller.GetAllCategories();
        }
        private void CalculateTotalPrice()
        {
            decimal total = 0;

            foreach (DataRow row in addedProductsTable.Rows)
            {
                decimal price = string.IsNullOrEmpty(row["ProductPrice"]?.ToString()) ? 0 : Convert.ToDecimal(row["ProductPrice"]);
                int qty = string.IsNullOrEmpty(row["ProductQuantity"]?.ToString()) ? 0 : Convert.ToInt32(row["ProductQuantity"]);
                decimal catPrice = string.IsNullOrEmpty(row["CategoryPrice"]?.ToString()) ? 0 : Convert.ToDecimal(row["CategoryPrice"]);

                total += (price * qty) + catPrice;
            }

            textBox7.Text = total.ToString("F2");
        }

        private void UpdateTransposedView()
        {
            DataTable transposed = new DataTable();
            transposed.Columns.Add("Details");

            for (int i = 0; i < addedProductsTable.Rows.Count; i++)
            {
                transposed.Columns.Add($"Service {i + 1}");
            }

            for (int j = 0; j < addedProductsTable.Columns.Count; j++)
            {
                DataRow row = transposed.NewRow();
                row["Details"] = addedProductsTable.Columns[j].ColumnName;

                for (int i = 0; i < addedProductsTable.Rows.Count; i++)
                {
                    row[$"Service {i + 1}"] = addedProductsTable.Rows[i][j];
                }

                transposed.Rows.Add(row);
            }

            dataGridView3.DataSource = transposed;
        }
        private void InitializeAddedProductsTable()
        {
            addedProductsTable.Columns.Add("ProductID", typeof(string));
            addedProductsTable.Columns.Add("ProductName", typeof(string));
            addedProductsTable.Columns.Add("ProductPrice", typeof(string));
            addedProductsTable.Columns.Add("ProductQuantity", typeof(string));
            addedProductsTable.Columns.Add("CategoryID", typeof(string));
            addedProductsTable.Columns.Add("CategoryName", typeof(string));
            addedProductsTable.Columns.Add("CategoryPrice", typeof(string));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ProductID"].Value.ToString();
                textBox2.Text = row.Cells["ProductName"].Value.ToString();
                textBox3.Text = row.Cells["ProductPrice"].Value.ToString();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                textBox6.Text = row.Cells["CategoryID"].Value.ToString();
                textBox5.Text = row.Cells["CategoryName"].Value.ToString();
                textBox10.Text = row.Cells["CategoryPrice"].Value.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
             string.IsNullOrWhiteSpace(textBox2.Text) ||
             string.IsNullOrWhiteSpace(textBox3.Text) ||
             string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill in all product details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            addedProductsTable.Rows.Add(
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                null,
                null,
                null
            );

            MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CalculateTotalPrice();
            UpdateTransposedView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox10.Text))
            {
                MessageBox.Show("Please fill in all category details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (addedProductsTable.Rows.Count == 0)
            {
                MessageBox.Show("Please add product first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow lastRow = addedProductsTable.Rows[addedProductsTable.Rows.Count - 1];
            lastRow["CategoryID"] = textBox6.Text;
            lastRow["CategoryName"] = textBox5.Text;
            lastRow["CategoryPrice"] = textBox10.Text;

            MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CalculateTotalPrice();
            UpdateTransposedView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox6.Clear(); textBox5.Clear(); textBox10.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text) ||
              string.IsNullOrWhiteSpace(textBox8.Text) ||
              string.IsNullOrWhiteSpace(textBox9.Text))
            {
                MessageBox.Show("Fill Total Bill, Customer ID and Phone!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BillingModel billing = new BillingModel
            {
                BillingID = controller.GetNextBillingID(),
                CustomerID = textBox8.Text,
                CustomerPhone = textBox9.Text,
                TotalBill = Convert.ToDecimal(textBox7.Text),
                BillingDate = dateTimePicker1.Value.ToShortDateString(),
                CategoryID = textBox6.Text,
                ProductID = textBox1.Text
            };

            bool success = controller.InsertBilling(billing);

            if (success)
            {
                MessageBox.Show("Billing saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save billing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
