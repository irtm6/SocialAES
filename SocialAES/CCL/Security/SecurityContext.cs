using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL.Security.Identity;

namespace CCL.Security
{
    public static class SecurityContext
    {
        static BaseUser _user = null;
        public static BaseUser GetUser()
        {
            return _user;
        }
        public static void SetUser(BaseUser user)
        {
            _user = user;
        }
    }

}
