using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BeautySalonManagementSystem.Model;
namespace BeautySalonManagementSystem.Controller
{
    public class BillingController
    {
        private readonly string connectionString = "Data Source=DESKTOP-UC1CQR5;Initial Catalog=SalonBD;User ID=sa; integrated security=SSPI";

        public DataTable GetAllProducts()
        {
            return ExecuteSelectQuery("SELECT * FROM Product");
        }

        public DataTable GetAllCategories()
        {
            return ExecuteSelectQuery("SELECT * FROM Category");
        }

        private DataTable ExecuteSelectQuery(string query)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
            }
            return table;
        }

        public int GetNextBillingID()
        {
            int newBillingID = 1;
            string query = "SELECT MAX(BillingID) FROM Billing";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    newBillingID = Convert.ToInt32(result) + 1;
                }
            }
            return newBillingID;
        }

        public bool InsertBilling(BillingModel billing)
        {
            string query = @"INSERT INTO Billing (CustomerPhone, BillingID, TotalBill, CustomerID, BillingDate, CategoryID, ProductID)
                             VALUES (@CustomerPhone, @BillingID, @TotalBill, @CustomerID, @BillingDate, @CategoryID, @ProductID)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@CustomerPhone", billing.CustomerPhone);
                cmd.Parameters.AddWithValue("@BillingID", billing.BillingID);
                cmd.Parameters.AddWithValue("@TotalBill", billing.TotalBill);
                cmd.Parameters.AddWithValue("@CustomerID", billing.CustomerID);
                cmd.Parameters.AddWithValue("@BillingDate", billing.BillingDate);
                cmd.Parameters.AddWithValue("@CategoryID", billing.CategoryID);
                cmd.Parameters.AddWithValue("@ProductID", billing.ProductID);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
