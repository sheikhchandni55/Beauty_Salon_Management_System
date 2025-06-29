using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BeautySalonManagementSystem.Model;
namespace BeautySalonManagementSystem.Controller
{
    public class AppController
    {
        private readonly string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

        public int GetNextAppointmentID()
        {
            int newID = 1;
            string query = "SELECT MAX(AppointmentID) FROM Appointment";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                    newID = Convert.ToInt32(result) + 1;
            }

            return newID;
        }

        public List<string> GetUnavailableTimes(string date)
        {
            List<string> times = new List<string>();
            string query = "SELECT AppointmentTime FROM Appointment WHERE AppointmentDate = @AppointmentDate";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@AppointmentDate", date);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    times.Add(reader["AppointmentTime"].ToString());
                }
            }

            return times;
        }

        public bool AddAppointment(AppUser appUser)
        {
            string query = @"INSERT INTO Appointment 
                (AppointmentID, ServiceName, CategoryName, AppointmentDate, AppointmentTime, CustomerID)
                VALUES (@AppointmentID, @ServiceName, @CategoryName, @AppointmentDate, @AppointmentTime, @CustomerID)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@AppointmentID", appUser.AppointmentID);
                cmd.Parameters.AddWithValue("@ServiceName", appUser.ServiceName);
                cmd.Parameters.AddWithValue("@CategoryName", appUser.CategoryName);
                cmd.Parameters.AddWithValue("@AppointmentDate", appUser.AppointmentDate);
                cmd.Parameters.AddWithValue("@AppointmentTime", appUser.AppointmentTime);
                cmd.Parameters.AddWithValue("@CustomerID", appUser.CustomerID);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
