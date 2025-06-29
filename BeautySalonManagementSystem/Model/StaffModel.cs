using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonManagementSystem.Model
{
    class StaffModel
    {
        public int StaffID { get; set; }

        public StaffModel(int id)
        {
            StaffID = id;
        }
    }
}

