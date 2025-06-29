using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonManagementSystem.Model
{
    public class AdminModel
    {
        public int AdminID { get; set; }

        public AdminModel(int id)
        {
            AdminID = id;
        }
    }
}
