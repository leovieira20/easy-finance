using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Db;

public class InMemoryEFCreditCardTransactionRepository : ICreditCardTransactionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public InMemoryEFCreditCardTransactionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<CreditCardTransaction>> GetAsync(CreditCardId creditCardId, DateTime startDate, DateTime endDate)
    {
        return _dbContext
            .CreditCardTransactions
            .Where(x => x.CreditCardId == creditCardId)
            .Where(x => x.TransactionDate >= startDate && x.TransactionDate <= endDate)
            .ToListAsync();
    }

    public Task RegisterAsync(CreditCardTransaction transaction)
    {
        _dbContext
            .CreditCardTransactions
            .Add(transaction);

        return _dbContext.SaveChangesAsync();
    }
}