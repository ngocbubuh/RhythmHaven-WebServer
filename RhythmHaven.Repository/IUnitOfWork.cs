using RhythmHaven.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Repository
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        int Save();
        void Commit();
        void Rollback();
    }
}
