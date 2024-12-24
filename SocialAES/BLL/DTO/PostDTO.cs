using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PostDTO
    {
        public int postID { get; set; }
        public int userID { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
    }
}
