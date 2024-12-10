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
    public class PostRepository
        : BaseRepository<Post>, IPostRepository
    {
        internal PostRepository(SocialAESContext context)
                : base(context)
        {

        }
    }
}