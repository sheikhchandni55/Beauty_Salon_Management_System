using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BeautySalonManagementSystem.Model;
namespace BeautySalonManagementSystem.Controller
{
    public class CusUpdateController
    {
        private readonly string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

        public bool CreateUser(CusUpdate user)
        {
            string query = @"INSERT INTO userInfo (UserID, UserName, UserPass, UserPNo, UserAdd, UserEmail, UserRole)
                             VALUES (@UserID, @UserName, @UserPass, @UserPNo, @UserAdd, @UserEmail, @UserRole)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", user.UserID);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@UserPass", user.UserPass);
                command.Parameters.AddWithValue("@UserPNo", user.UserPNo);
                command.Parameters.AddWithValue("@UserAdd", user.UserAdd);
                command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                command.Parameters.AddWithValue("@UserRole", user.UserRole);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}
