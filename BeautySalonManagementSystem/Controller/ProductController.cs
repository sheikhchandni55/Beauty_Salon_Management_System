using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BeautySalonManagementSystem.Model;
using System.Windows.Forms;
namespace BeautySalonManagementSystem.Controller
{

   
    public class ProductController
    {
        private readonly string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa;Integrated Security=SSPI";

        public DataTable GetAllProducts()
        {
            string query = "SELECT * FROM Product";
            return ExecuteQuery(query);
        }

        public DataTable SearchProduct(string searchTerm)
        {
            string query = @"SELECT * FROM Product
                             WHERE ProductID LIKE @searchTerm OR ProductName LIKE @searchTerm OR ProductPrice LIKE @searchTerm";

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

        public bool AddProduct(ProductModel product)
        {
            string query = @"INSERT INTO Product (ProductID, ProductName, ProductPrice, ProductExp_Date)
                             VALUES (@ProductID, @ProductName, @ProductPrice, @ProductExpDate)";
            return ExecuteNonQuery(query, product);
        }

        public bool UpdateProduct(ProductModel product)
        {
            string query = @"UPDATE Product
                             SET ProductName = @ProductName, ProductPrice = @ProductPrice, ProductExp_Date = @ProductExpDate
                             WHERE ProductID = @ProductID";
            return ExecuteNonQuery(query, product);
        }

        public bool DeleteProduct(string productId)
        {
            string query = "DELETE FROM Product WHERE ProductID = @ProductID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductID", productId);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        private DataTable ExecuteQuery(string query)
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

        private bool ExecuteNonQuery(string query, ProductModel product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                command.Parameters.AddWithValue("@ProductExpDate", product.ProductExpDate);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
