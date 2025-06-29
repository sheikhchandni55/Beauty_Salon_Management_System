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
    public partial class CusService : Form
    {
        private readonly int customerId;
        private readonly CusServiceController controller;

        public CusService(int i)
        {
            InitializeComponent();
            customerId = i;
            controller = new CusServiceController();
        }

        private void CusService_Load(object sender, EventArgs e)
        {
            LoadServiceData();
        }

        private void LoadServiceData()
        {
            DataTable serviceData = controller.GetAllServices();
            dataGridView1.DataSource = serviceData;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
