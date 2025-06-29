using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalonManagementSystem.Model;
using BeautySalonManagementSystem.View;
using System.Windows.Forms;

namespace BeautySalonManagementSystem.Controller
{
    class StaffController
    {
        private Form activeForm = null;
        private Panel containerPanel;
        private int staffId;

        public StaffController(Panel panel, int id)
        {
            containerPanel = panel;
            staffId = id;
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            containerPanel.Controls.Add(childForm);
            containerPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void ShowDashboard() => OpenChildForm(new UserDashBoard());
        public void ShowAppointment() => OpenChildForm(new Appointment(staffId));
        public void ShowUserManagement() => OpenChildForm(new Form4(staffId));
        public void ShowCategory() => OpenChildForm(new Category(staffId));
        public void ShowProduct() => OpenChildForm(new Product(staffId));
        public void ShowService() => OpenChildForm(new Service(staffId));
        public void ShowBilling() => OpenChildForm(new Billing(staffId));
        public void ShowProfile() => OpenChildForm(new Form7(staffId));
    }
}
