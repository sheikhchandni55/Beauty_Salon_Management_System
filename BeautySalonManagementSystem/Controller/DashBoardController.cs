using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BeautySalonManagementSystem.Controller
{
    public class DashBoardController
    {
        private readonly string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

        public DataTable LoadAppointments()
        {
            string query = "SELECT * FROM Appointment";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            }
        }
    }
}
