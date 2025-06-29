using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautySalonManagementSystem.View;

namespace BeautySalonManagementSystem.Controller
{
    public class AdminController
    {
        private readonly Panel panel;
        private readonly int adminId;
        private Form activeForm;

        public AdminController(Panel panel, int id)
        {
            this.panel = panel;
            this.adminId = id;
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel.Controls.Add(childForm);
            panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void ShowDashboard() => OpenChildForm(new UserDashBoard());
        public void ShowUserForm() => OpenChildForm(new Form4(adminId));
        public void ShowCategoryForm() => OpenChildForm(new Category(adminId));
        public void ShowProductForm() => OpenChildForm(new Product(adminId));
        public void ShowBillingForm() => OpenChildForm(new Billing(adminId));
        public void ShowProfileForm() => OpenChildForm(new Form7(adminId));
        public void ShowCreateUserForm() => OpenChildForm(new Form3(adminId));
    }
}
