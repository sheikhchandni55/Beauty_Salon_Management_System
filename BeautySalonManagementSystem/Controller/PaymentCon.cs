using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BeautySalonManagementSystem.Model;
namespace BeautySalonManagementSystem.Controller
{
    class PaymentCon
    {
        private readonly string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

        public bool ValidateMobileBankingPayment(PaymentMod model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Payment WHERE PhoneNo = @PhoneNo AND Pin = @Pin";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PhoneNo", model.PhoneNo);
                command.Parameters.AddWithValue("@Pin", model.Pin);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public bool VerifyCardPayment(PaymentMod model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Payment WHERE CHName = @CHName AND CardNo = @CardNo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CHName", model.CardHolderName);
                command.Parameters.AddWithValue("@CardNo", model.CardNumber);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count == 1;
            }
        }
    }
}

