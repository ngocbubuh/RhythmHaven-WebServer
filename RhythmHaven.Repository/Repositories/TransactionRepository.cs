using Microsoft.EntityFrameworkCore;
using RhythmHaven.Repository.Common;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Repository.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private RhythmHavenContext _context;
        public TransactionRepository(RhythmHavenContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Pagination<Transaction>> GetAllByUserId(Guid userId, PaginationParameter paginationParameter)
        {
            var itemCount = await _context.Transactions.CountAsync();
            var items = await _context.Transactions.Where(x => x.Id.Equals(userId))
                                    .Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                                    .Take(paginationParameter.PageSize)
                                    .AsNoTracking()
                                    .ToListAsync();
            var result = new Pagination<Transaction>(items, itemCount, paginationParameter.PageIndex, paginationParameter.PageSize);
            return result;
        }
    }
}
