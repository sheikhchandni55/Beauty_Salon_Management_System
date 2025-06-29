using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BeautySalonManagementSystem.Model;
namespace BeautySalonManagementSystem.Controller
{
    public class PasswordResetController
    {
      
            private readonly string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

            public bool ValidatePasswords(string newPassword, string confirmPassword, out string errorMessage)
            {
                if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
                {
                    errorMessage = "All fields must be filled out.";
                    return false;
                }

                if (newPassword != confirmPassword)
                {
                    errorMessage = "New password and confirm password do not match.";
                    return false;
                }

                errorMessage = "";
                return true;
            }

            public string GetCurrentPassword(int userId)
            {
                string storedPassword = "";
                string query = "SELECT UserPass FROM userInfo WHERE UserID = @UserID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        storedPassword = reader["UserPass"].ToString();
                    }
                }

                return storedPassword;
            }

            public bool UpdatePassword(PasswordResetModel model)
            {
                string query = "UPDATE userInfo SET UserPass = @NewPassword WHERE UserID = @UserID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewPassword", model.NewPassword);
                    command.Parameters.AddWithValue("@UserID", model.UserID);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
