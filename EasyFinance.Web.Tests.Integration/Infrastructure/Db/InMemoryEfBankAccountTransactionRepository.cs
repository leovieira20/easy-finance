using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFinance.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Db;

public class InMemoryEfBankAccountTransactionRepository : IBankAccountTransactionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public InMemoryEfBankAccountTransactionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<BankAccountTransaction>> GetForBankAccountAsync(BankAccountId bankAccountId, DateTime startDate, DateTime endDate)
    {
        return _dbContext.BankAccountTransactions
            .Where(x => x.BankAccountId == bankAccountId)
            .Where(x => x.Date.Date >= startDate.Date.Date)
            .Where(x => x.Date.Date < endDate.Date.Date)
            .ToListAsync();
    }
}