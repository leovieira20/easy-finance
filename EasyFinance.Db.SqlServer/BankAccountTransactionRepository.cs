using EasyFinance.Db.SqlServer.EF;
using EasyFinance.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace EasyFinance.Db.SqlServer;

class BankAccountTransactionRepository : IBankAccountTransactionRepository
{
    private readonly EasyFinanceDbContext _context;

    public BankAccountTransactionRepository(EasyFinanceDbContext context)
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