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
    public partial class Appointment : Form
    {
        private readonly AppController controller = new AppController();
        private readonly int idf3;

        private readonly List<string> allTimes = new List<string>
        {
            "8:00 - 9:00 AM", "9:00 - 10:00 AM", "10:00 - 11:00 AM",
            "11:00 - 12:00 PM", "12:00 - 1:00 PM", "1:00 - 2:00 PM",
            "2:00 - 3:00 PM", "3:00 - 4:00 PM", "4:00 - 5:00 PM",
            "5:00 - 6:00 PM", "6:00 - 7:00 PM", "7:00 - 8:00 PM",
            "8:00 - 9:00 PM", "9:00 - 10:00 PM"
        };

        public Appointment(int i3)
        {
            InitializeComponent();
            idf3 = i3;
            comboBox3.DataSource = new List<string>(allTimes);
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string selectedDate = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            var unavailable = controller.GetUnavailableTimes(selectedDate);
            comboBox3.DataSource = allTimes.Except(unavailable).ToList();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var appUser = new AppUser
            {
                AppointmentID = controller.GetNextAppointmentID(),
                CustomerID = textBox1.Text.Trim(),
                ServiceName = comboBox1.Text,
                CategoryName = comboBox2.Text,
                AppointmentDate = dateTimePicker1.Value.ToString("dd/MM/yyyy"),
                AppointmentTime = comboBox3.Text
            };

            if (string.IsNullOrWhiteSpace(appUser.CustomerID) || string.IsNullOrWhiteSpace(appUser.ServiceName)
                || string.IsNullOrWhiteSpace(appUser.CategoryName) || string.IsNullOrWhiteSpace(appUser.AppointmentTime))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = controller.AddAppointment(appUser);

            if (success)
            {
                MessageBox.Show("Appointment created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("Failed to create the appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    

