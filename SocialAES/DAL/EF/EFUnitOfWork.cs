using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private SocialAESContext db;
        private UserRepository _userRepository;
        private PostRepository _postRepository;
        public EFUnitOfWork(DbContextOptions options)
        {
            db = new SocialAESContext(options);
        }
        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(db);
                return _userRepository;
            }
        }
        public IPostRepository Posts
        {
            get
            {
                if (_postRepository == null)
                    _postRepository = new PostRepository(db);
                return _postRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
