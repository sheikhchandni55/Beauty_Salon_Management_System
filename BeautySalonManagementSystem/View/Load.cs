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
    public partial class Load : Form
    {
        private LoadController loadController;

        public Load()
        {
            loadController = new LoadController();
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!loadController.IsLoadingComplete())
            {
                loadController.UpdateProgress();
                progressBar1.Value = loadController.GetProgress();
                label2.Text = progressBar1.Value + "%";
            }
            else
            {
                timer1.Stop();
                new Form1().Show();
                this.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Load_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
