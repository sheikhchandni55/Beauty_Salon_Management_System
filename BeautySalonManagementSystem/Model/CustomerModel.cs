using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonManagementSystem.Model
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }

        public CustomerModel(int customerId)
        {
            CustomerID = customerId;
        }
    }
}

