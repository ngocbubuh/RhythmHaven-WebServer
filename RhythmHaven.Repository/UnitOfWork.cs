using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Repository.Repositories;
using RhythmHaven.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RhythmHavenContext _context;
        private IDbContextTransaction _transaction;
        private IAccountRepository _accountRepository;

        public UnitOfWork(RhythmHavenContext context)
        {
            _context = context;
        }

        public IAccountRepository AccountRepository 
        {
            get
            {
                return _accountRepository ??= new AccountRepository(_context);

            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
                _transaction?.Commit();
            }
            catch (Exception)
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
