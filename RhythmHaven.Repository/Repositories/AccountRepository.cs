using Microsoft.EntityFrameworkCore;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Repository.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private RhythmHavenContext _context;
        public AccountRepository(RhythmHavenContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Account> GetByUsernameAsync(string username)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.UserName.Equals(username));
        }
    }
}
