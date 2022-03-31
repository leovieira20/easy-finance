using EasyFinance.Db.SqlServer.EF;
using EasyFinance.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace EasyFinance.Db.SqlServer;

class BankAccountRepository : IBankAccountRepository
{
    private readonly EasyFinanceDbContext _context;

    public BankAccountRepository(EasyFinanceDbContext context)
    {
        _context = context;
    }
    
    public Task CreateAsync(BankAccount bankAccount)
    {
        _context.BankAccounts.Add(bankAccount);
        return _context.SaveChangesAsync();
    }

    public Task<BankAccount?> GetAsync(BankAccountId bankAccountId)
    {
        return _context
            .BankAccounts
            .SingleOrDefaultAsync(x => x.Id == bankAccountId);
    }

    public Task<BankAccount?> GetWithTransactionsAsync(BankAccountId bankAccountId)
    {
        return _context
            .BankAccounts
            .Include(x => x.Transactions)
            .SingleOrDefaultAsync(x => x.Id == bankAccountId);
    }

    public Task Update(BankAccount bankAccount)
    {
        _context.BankAccounts.Update(bankAccount);
        return _context.SaveChangesAsync();
    }
}