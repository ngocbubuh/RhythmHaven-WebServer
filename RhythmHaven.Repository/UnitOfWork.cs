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
        private ICartRepository _cartRepository;
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IProductRepository _productRepository;
        private ITransactionRepository _transactionRepository;

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

        public ICartRepository CartRepository
        {
            get
            {
                return _cartRepository ??= new CartRepository(_context);
            }
        }

        public IOrderDetailRepository OrderDetailRepository
        {
            get
            {
                return _orderDetailRepository ??= new OrderDetailRepository(_context);
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                return _orderRepository ??= new OrderRepository(_context);
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository ??= new ProductRepository(_context);
            }
        }

        public ITransactionRepository TransactionRepository
        {
            get
            {
                return _transactionRepository ??= new TransactionRepository(_context);
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
