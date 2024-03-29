using CreditCards.Domain;
using CreditCards.Db.SqlServer.EF;
using Microsoft.EntityFrameworkCore;

namespace CreditCards.Db.SqlServer;

class CreditCardTransactionRepository : ICreditCardTransactionRepository
{
    private readonly CreditCardsDbContext _context;

    public CreditCardTransactionRepository(CreditCardsDbContext context)
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