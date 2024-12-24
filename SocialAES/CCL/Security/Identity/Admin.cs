using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Admin
 : BaseUser
    {
        public Admin(int userId, string username, string email)
        : base(userId, username, email, nameof(Admin))
        {
        }
    }
}
