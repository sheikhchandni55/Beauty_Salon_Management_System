using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonManagementSystem.Model
{
   public class BillingModel
    {
        public int BillingID { get; set; }
        public decimal TotalBill { get; set; }
        public string CustomerID { get; set; }
        public string CustomerPhone { get; set; }
        public string BillingDate { get; set; }
        public string CategoryID { get; set; }
        public string ProductID { get; set; }
    }
}
