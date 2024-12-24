using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public abstract class BaseUser
    {
        public BaseUser(int userId, string username, string email, string userType)
        {
            UserId = userId;
            UserName = username;
            Email = email;
            UserType = userType;
        }
        public int UserId { get; }
        public string UserName { get; }
        public string Email { get; }
        protected string UserType { get; }
    }
}
