using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BeautySalonManagementSystem.Model;
using BeautySalonManagementSystem.View;
namespace BeautySalonManagementSystem.Controller
{
    public class ManageController
    {
        private readonly string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa;integrated security=SSPI";

        public DataTable GetAllUsers()
        {
            string query = "SELECT * FROM userInfo";
            return ExecuteQuery(query);
        }

        public ManageUser GetUserById(int id)
        {
            string query = "SELECT UserID, UserName, UserPNo, UserAdd, UserEmail, UserRole FROM userInfo WHERE UserID = @UserID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new ManageUser
                    {
                        UserID = (int)reader["UserID"],
                        UserName = reader["UserName"].ToString(),
                        UserPNo = reader["UserPNo"].ToString(),
                        UserAdd = reader["UserAdd"].ToString(),
                        UserEmail = reader["UserEmail"].ToString(),
                        UserRole = reader["UserRole"].ToString()
                    };
                }
                return null;
            }
        }

        public DataTable SearchUsers(string term)
        {
            string query = @"SELECT * FROM userInfo WHERE 
                UserId LIKE @searchTerm OR UserPNo LIKE @searchTerm OR 
                UserName LIKE @searchTerm OR UserRole LIKE @searchTerm OR 
                UserAdd LIKE @searchTerm OR UserEmail LIKE @searchTerm";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@searchTerm", $"%{term}%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public string GetUserRoleById(int id)
        {
            string query = "SELECT UserRole FROM userInfo WHERE UserID = @UserID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", id);
                conn.Open();
                var role = cmd.ExecuteScalar();
                return role?.ToString();
            }
        }

        public bool UpdateUser(ManageUser user)
        {
            string query = "UPDATE userInfo SET UserName = @UserName, UserPNo = @UserPNo, UserAdd = @UserAdd, UserEmail = @UserEmail WHERE UserID = @UserID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@UserPNo", user.UserPNo);
                cmd.Parameters.AddWithValue("@UserAdd", user.UserAdd);
                cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteUser(int id)
        {
            string query = "DELETE FROM userInfo WHERE UserID = @UserID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private DataTable ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
    }
}
