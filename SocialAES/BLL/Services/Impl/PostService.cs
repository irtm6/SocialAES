using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Impl
{
    public class PostService
 : IPostService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;
        public PostService(
        IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }
 /// <exception cref="MethodAccessException"></exception>
 public IEnumerable<PostDTO> GetPosts(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Admin)
               && userType != typeof(CCL.Security.Identity.User))
            {
                throw new MethodAccessException();
            }
            var userId = user.UserId;
            var postsEntities =
            _database
            .Posts
            .Find(z => z.userID == userId, pageNumber, pageSize);
            var mapper =
            new MapperConfiguration(
            cfg => cfg.CreateMap<Post, PostDTO>()
            ).CreateMapper();
            var postsDto =
            mapper
            .Map<IEnumerable<Post>, List<PostDTO>>(
            postsEntities);
            return postsDto;
        }
    }
}


