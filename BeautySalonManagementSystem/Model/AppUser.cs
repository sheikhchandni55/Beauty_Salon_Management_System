using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonManagementSystem.Model
{
    public class AppUser
    {
        public int AppointmentID { get; set; }
        public string ServiceName { get; set; }
        public string CategoryName { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string CustomerID { get; set; }
    }
}
