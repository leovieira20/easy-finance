using EasyFinance.Db.SqlServer.EF;
using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace EasyFinance.Db.SqlServer;

class CreditCardTransactionRepository : ICreditCardTransactionRepository
{
    private readonly EasyFinanceDbContext _context;

    public CreditCardTransactionRepository(EasyFinanceDbContext context)
    {
        _context = context;
    }
    
    public Task<List<CreditCardTransaction>> GetAsync(CreditCardId requestCreditCardId, DateTime requestStartDate, DateTime requestEndDate)
    {
        return _context
            .CreditCardTransactions
            .Where(x => x.CreditCardId == requestCreditCardId)
            .Where(x => x.Date >= requestStartDate)
            .Where(x => x.Date <= requestEndDate)
            .OrderBy(x => x.Date)
            .ToListAsync();
    }

    public Task RegisterAsync(CreditCardTransaction transaction)
    {
        _context.CreditCardTransactions.Add(transaction);
        return _context.SaveChangesAsync();
    }
}