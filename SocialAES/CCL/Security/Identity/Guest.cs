using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Guest
 : BaseUser
    {
        public Guest(int userId, string username, string email)
        : base(userId, username, email, nameof(Guest))
        {
        }
    }
}
