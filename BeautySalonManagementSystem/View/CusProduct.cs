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
namespace BeautySalonManagementSystem.View
{
    public partial class CusProduct : Form
    {
        private readonly CusProductController controller;
        private int id;

        public CusProduct(int i)
        {
            InitializeComponent();
            id = i;
            controller = new CusProductController();
            LoadCategoryData();
        }

        private void LoadCategoryData()
        {
            DataTable table = controller.GetAllCategories();
            dataGridView1.DataSource = table;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CusProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
