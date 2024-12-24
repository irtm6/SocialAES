﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class User
 : BaseUser
    {
        public User(int userId, string username, string email)
        : base(userId, username, email, nameof(User))
        {
        }
    }

}
