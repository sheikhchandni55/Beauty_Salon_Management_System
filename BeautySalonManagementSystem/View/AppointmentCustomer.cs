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
    public partial class AppointmentCustomer : Form
    {
        private int idf3;
        private readonly AppCusController controller;
        private readonly List<string> allTimes = new List<string>
        {
            "8:00 - 9:00 AM", "9:00 - 10:00 AM", "10:00 - 11:00 AM", "11:00 - 12:00 PM",
            "12:00 - 1:00 PM", "1:00 - 2:00 PM", "2:00 - 3:00 PM", "3:00 - 4:00 PM",
            "4:00 - 5:00 PM", "5:00 - 6:00 PM", "6:00 - 7:00 PM", "7:00 - 8:00 PM",
            "8:00 - 9:00 PM", "9:00 - 10:00 PM"
        };

        public AppointmentCustomer(int i3)
        {
            InitializeComponent();
            idf3 = i3;
            controller = new AppCusController();

            comboBox3.DataSource = new List<string>(allTimes);
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshAvailableTimes();
        }

        private void RefreshAvailableTimes()
        {
            string selectedDate = dateTimePicker1.Value.Date.ToString("dd/MM/yyyy");
            var unavailable = controller.GetUnavailableTimes(selectedDate);
            var available = allTimes.Except(unavailable).ToList();
            comboBox3.DataSource = available;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var appointment = new AppCusModel
            {
                AppointmentID = controller.GetNextAppointmentID(),
                ServiceName = comboBox1.Text,
                CategoryName = comboBox2.Text,
                AppointmentDate = dateTimePicker1.Value.Date.ToString("dd/MM/yyyy"),
                AppointmentTime = comboBox3.Text,
                CustomerID = idf3
            };

            // Validation
            if (string.IsNullOrWhiteSpace(appointment.ServiceName) ||
                string.IsNullOrWhiteSpace(appointment.CategoryName) ||
                string.IsNullOrWhiteSpace(appointment.AppointmentDate) ||
                string.IsNullOrWhiteSpace(appointment.AppointmentTime))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = controller.SaveAppointment(appointment);

            if (success)
            {
                MessageBox.Show("Appointment created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("Failed to create appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    

    