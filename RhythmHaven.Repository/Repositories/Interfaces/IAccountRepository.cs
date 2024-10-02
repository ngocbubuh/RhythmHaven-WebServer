using Microsoft.Identity.Client;
using RhythmHaven.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Repository.Repositories.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        public Task<Account> GetByUsernameAsync(string username);
    }
}
