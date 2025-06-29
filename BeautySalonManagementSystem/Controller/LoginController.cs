using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BeautySalonManagementSystem.Model;

namespace BeautySalonManagementSystem.Controller
{
public    class LoginController
    {
        private string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

        public string AuthenticateUser(LoginModel user)
        {
            string query = "SELECT UserRole FROM userInfo WHERE UserID = @UserID AND UserPass COLLATE SQL_Latin1_General_CP1_CS_AS = @UserPass";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", user.UserID);
                command.Parameters.AddWithValue("@UserPass", user.UserPass);

                connection.Open();
                var result = command.ExecuteScalar();
                return result?.ToString(); // returns UserRole or null
            }
        }
    }
}

