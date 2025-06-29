using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautySalonManagementSystem.View;
using BeautySalonManagementSystem.Model;
namespace BeautySalonManagementSystem.Controller
{
    public class CustomerController
    {
        private readonly Panel panel;
        private Form activeForm = null;
        private readonly CustomerModel customer;

        public CustomerController(Panel panelControl, CustomerModel customerModel)
        {
            panel = panelControl;
            customer = customerModel;
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

        public void LoadDashboard() => OpenChildForm(new DashBoard(customer.CustomerID));
        public void LoadAppointments() => OpenChildForm(new AppointmentCustomer(customer.CustomerID));
        public void LoadServices() => OpenChildForm(new CusService(customer.CustomerID));
        public void LoadCategories() => OpenChildForm(new CusCategory(customer.CustomerID));
        public void LoadProducts() => OpenChildForm(new CusProduct(customer.CustomerID));
        public void ShowPaymentForm() => new Payment(customer.CustomerID).Show();
        public void ShowForm8()
        {
            Form8 f8 = new Form8(customer.CustomerID); // Or new Form8() if no param needed
            f8.Show();
        }
    }
}

