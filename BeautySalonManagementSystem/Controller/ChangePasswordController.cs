using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BeautySalonManagementSystem.Model;
namespace BeautySalonManagementSystem.Controller
{
    public class ChangePasswordController
    {
        private readonly string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

        public bool ValidateInput(ChangePasswordModel model, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(model.CurrentPassword) ||
                string.IsNullOrWhiteSpace(model.NewPassword) ||
                string.IsNullOrWhiteSpace(model.ConfirmPassword))
            {
                errorMessage = "All fields must be filled out.";
                return false;
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                errorMessage = "New password and confirm password do not match.";
                return false;
            }

            errorMessage = "";
            return true;
        }

        public bool VerifyCurrentPassword(int userId, string currentPassword)
        {
            string query = "SELECT UserPass FROM userInfo WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", userId);
                connection.Open();

                var result = command.ExecuteScalar();
                return result != null && result.ToString() == currentPassword;
            }
        }

        public bool UpdatePassword(int userId, string newPassword)
        {
            string query = "UPDATE userInfo SET UserPass = @NewPassword WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NewPassword", newPassword); // Consider hashing in future
                command.Parameters.AddWithValue("@UserID", userId);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
