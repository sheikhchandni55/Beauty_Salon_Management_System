using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BeautySalonManagementSystem.Model;
namespace BeautySalonManagementSystem.Controller
{
    public class UserDashBoardCon
    {
       
            private readonly string conString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

            public DataTable GetAppointmentData()
            {
                string query = "SELECT * FROM Appointment";
                return GetData(query);
            }

            public DataTable GetBillingData()
            {
                string query = "SELECT * FROM Billing";
                return GetData(query);
            }

            public DataTable SearchBillingByCustomerID(string searchTerm)
            {
                string query = "SELECT * FROM Billing WHERE CustomerID LIKE @searchTerm";
                using (SqlConnection connection = new SqlConnection(conString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }

            public UserDashBoardMod GetTotalStaff()
            {
                string query = "SELECT COUNT(UserID) as totalStaff FROM userInfo WHERE UserRole = 'Staff'";
                UserDashBoardMod model = new UserDashBoardMod();

                using (SqlConnection con = new SqlConnection(conString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() && reader["totalStaff"] != DBNull.Value)
                    {
                        model.TotalStaff = (int)reader["totalStaff"];
                    }
                }

                return model;
            }

            private DataTable GetData(string query)
            {
                using (SqlConnection connection = new SqlConnection(conString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }
    }
