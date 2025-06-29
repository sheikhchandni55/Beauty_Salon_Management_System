using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonManagementSystem.Model
{
    public class CusServiceModel
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string CategoryName { get; set; }
        public decimal ServicePrice { get; set; }
    }
}
