using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Post
    {
        public int postID { get; set; }
        public int userID { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
    }
}
