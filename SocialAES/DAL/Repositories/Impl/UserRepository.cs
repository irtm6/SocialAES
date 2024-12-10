using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl
{
    public class UserRepository 
        : BaseRepository<User>, IUserRepository
    {
        internal UserRepository(SocialAESContext context) 
            : base(context) 
        {
        }
        public IEnumerable<User> FindByUserName(string userName)
        {
            // Пошук користувачів за UserName
            return _set.Where(user => user.UserName.Contains(userName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}
