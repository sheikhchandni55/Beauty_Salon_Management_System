using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BeautySalonManagementSystem.Model;
namespace BeautySalonManagementSystem.Controller
{
    public class AppCusController
    {
        private readonly string conString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

        public List<string> GetUnavailableTimes(string appointmentDate)
        {
            List<string> unavailableTimes = new List<string>();
            string query = "SELECT AppointmentTime FROM Appointment WHERE AppointmentDate = @AppointmentDate";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    unavailableTimes.Add(reader["AppointmentTime"].ToString());
                }
            }

            return unavailableTimes;
        }

        public int GetNextAppointmentID()
        {
            string query = "SELECT MAX(AppointmentID) FROM Appointment";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                    return Convert.ToInt32(result) + 1;
                else
                    return 1;
            }
        }

        public bool SaveAppointment(AppCusModel model)
        {
            string query = @"INSERT INTO Appointment 
            (AppointmentID, ServiceName, CategoryName, AppointmentDate, AppointmentTime, CustomerID)
            VALUES 
            (@AppointmentID, @ServiceName, @CategoryName, @AppointmentDate, @AppointmentTime, @CustomerID)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AppointmentID", model.AppointmentID);
                command.Parameters.AddWithValue("@ServiceName", model.ServiceName);
                command.Parameters.AddWithValue("@CategoryName", model.CategoryName);
                command.Parameters.AddWithValue("@AppointmentDate", model.AppointmentDate);
                command.Parameters.AddWithValue("@AppointmentTime", model.AppointmentTime);
                command.Parameters.AddWithValue("@CustomerID", model.CustomerID);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
