using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using BeautySalonManagementSystem.Model;
namespace BeautySalonManagementSystem.Controller
{
    public class CategoryController
    {
        private readonly string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

        public DataTable GetAllCategories()
        {
            string query = "SELECT * FROM Category";
            return ExecuteSelectQuery(query);
        }

        public DataTable SearchServices(string searchTerm)
        {
            string query = @"SELECT * FROM Service
                             WHERE ServiceID LIKE @searchTerm 
                                OR ServiceName LIKE @searchTerm";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable GetServiceById(string serviceId)
        {
            string query = "SELECT * FROM Service WHERE ServiceID = @ServiceID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ServiceID", serviceId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public bool InsertCategory(CategoryModel category)
        {
            string query = @"INSERT INTO Category (CategoryID, CategoryName, CategoryPrice, ServiceID) 
                             VALUES (@CategoryID, @CategoryName, @CategoryPrice, @ServiceID)";
            return ExecuteNonQuery(query, category);
        }

        public bool UpdateCategory(CategoryModel category)
        {
            string query = @"UPDATE Category
                             SET CategoryName = @CategoryName, 
                                 CategoryPrice = @CategoryPrice, 
                                 ServiceID = @ServiceID 
                             WHERE CategoryID = @CategoryID";
            return ExecuteNonQuery(query, category);
        }

        public bool DeleteCategory(string categoryId)
        {
            string query = "DELETE FROM Category WHERE CategoryID = @CategoryID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
        }

        private bool ExecuteNonQuery(string query, CategoryModel category)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                command.Parameters.AddWithValue("@CategoryPrice", category.CategoryPrice);
                command.Parameters.AddWithValue("@ServiceID", category.ServiceID);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
        }

        private DataTable ExecuteSelectQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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
            

    
