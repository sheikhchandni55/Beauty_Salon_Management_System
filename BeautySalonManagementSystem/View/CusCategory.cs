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
    public partial class CusCategory : Form
    {
        private int id;
        private CusCategoryController controller;

        public CusCategory(int i)
        {
            InitializeComponent();
            id = i;
            controller = new CusCategoryController();
            LoadCategoryData();
        }

        private void LoadCategoryData()
        {
            DataTable data = controller.GetAllCategories();
            dataGridView1.DataSource = data;
        }
      
    }
}
