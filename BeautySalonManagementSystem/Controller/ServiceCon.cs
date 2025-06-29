using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BeautySalonManagementSystem.Model;
using System.Data;
using System.Windows.Forms;
namespace BeautySalonManagementSystem.Controller
{
    public class ServiceCon
    {
        private readonly string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

        public DataTable GetAllServices()
        {
            string query = "SELECT * FROM Service";
            return ExecuteSelectQuery(query);
        }

        public DataTable SearchServices(string searchTerm)
        {
            string query = @"SELECT * FROM Service WHERE ServiceID LIKE @search OR ServiceName LIKE @search";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public bool AddService(ServiceMod service)
        {
            string query = "INSERT INTO Service (ServiceID, ServiceName) VALUES (@ServiceID, @ServiceName)";
            return ExecuteNonQuery(query, service);
        }

        public bool UpdateService(ServiceMod service)
        {
            string query = "UPDATE Service SET ServiceName = @ServiceName WHERE ServiceID = @ServiceID";
            return ExecuteNonQuery(query, service);
        }

        public bool DeleteService(string serviceID)
        {
            string query = "DELETE FROM Service WHERE ServiceID = @ServiceID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ServiceID", serviceID);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
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

        private bool ExecuteNonQuery(string query, ServiceMod service)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ServiceID", service.ServiceID);
                command.Parameters.AddWithValue("@ServiceName", service.ServiceName);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
                
            
        
    
