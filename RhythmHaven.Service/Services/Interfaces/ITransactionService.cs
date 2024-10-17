using RhythmHaven.Repository.Common;
using RhythmHaven.Service.BusinessModels;
using RhythmHaven.Service.BusinessModels.TransactionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services.Interfaces
{
    public interface ITransactionService
    {
        public Task<Pagination<TransactionModel>> GetAllByUsername(string username, PaginationParameter paginationParameter);
        public Task<TransactionModel> AddTransactionByVNPAYAsync(double amount, string username);
        public Task<TransactionModel> UpdateTransactionByVNPAYStatusAsync(VnPayModel model);
    }
}
