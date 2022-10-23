using BankAccountModule.Db.SqlServer.EF;
using BankAccountModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankAccountModule.Db.SqlServer;

class BankAccountTransactionRepository : IBankAccountTransactionRepository
{
    private readonly BankAccountsDbContext _context;

    public BankAccountTransactionRepository(BankAccountsDbContext context)
    {
        _context = context;
    }
    
    public Task<List<BankAccountTransaction>> GetForBankAccountAsync(BankAccountId bankAccountId, DateTime startDate,
        DateTime endDate)
    {
        return _context
            .BankAccountTransactions
            .Where(x => x.BankAccountId == bankAccountId)
            .Where(x => x.Date >= startDate)
            .Where(x => x.Date <= endDate)
            .OrderBy(x => x.Date)
            .ToListAsync();
    }
}