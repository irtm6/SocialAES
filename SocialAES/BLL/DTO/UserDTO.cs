using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; } 
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<Post>Posts { get; set; }
    }
}
