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
    public partial class DashBoard : Form
    {
        private readonly int id;
        private readonly DashBoardController controller;

        public DashBoard(int i)
        {
            InitializeComponent();
            id = i;
            controller = new DashBoardController();

            LoadAppointmentData();


        } 
        private void LoadAppointmentData()
        {
            DataTable data = controller.LoadAppointments();
            dataGridView1.DataSource = data;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2(id).Show();
        }
    }
}
