using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BeautySalonManagementSystem.Model;
namespace BeautySalonManagementSystem.Controller
{
    public class ProController
    {
        private readonly string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

        public bool SaveProfile(ProModel user)
        {
            string query = @"INSERT INTO userInfo 
                (UserID, UserName, UserPass, UserPNo, UserAdd, UserStartDate, UserSalary, UserEmail, UserRole) 
                VALUES 
                (@UserID, @UserName, @UserPass, @UserPNo, @UserAdd, @UserStartDate, @UserSalary, @UserEmail, @UserRole)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", user.UserID);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@UserPass", user.UserPass);
                command.Parameters.AddWithValue("@UserPNo", user.UserPNo);
                command.Parameters.AddWithValue("@UserAdd", user.UserAdd);
                command.Parameters.AddWithValue("@UserStartDate", user.UserStartDate);
                command.Parameters.AddWithValue("@UserSalary", user.UserSalary);
                command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                command.Parameters.AddWithValue("@UserRole", user.UserRole);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
