using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;
using DAL.Entities;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }
        IPostRepository Posts { get; }
        void Save();
    }
}
