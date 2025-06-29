using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonManagementSystem.Model
{
    public class ForgotPasswordModel
    {
        public string UserID { get; set; }
        public string UserPNo { get; set; }

        public ForgotPasswordModel(string userId, string userPNo)
        {
            UserID = userId;
            UserPNo = userPNo;
        }
    }
}
