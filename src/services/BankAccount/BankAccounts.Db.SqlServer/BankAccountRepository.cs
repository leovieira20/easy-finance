using BankAccounts.Domain.Aggregates.BankAccountAggregate;
using BankAccounts.Db.SqlServer.EF;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Db.SqlServer;

class BankAccountRepository : IBankAccountRepository
{
    private readonly BankAccountsDbContext _context;

    public BankAccountRepository(BankAccountsDbContext context)
    {
        _context = context;
    }
    
    public Task CreateAsync(BankAccount bankAccount)
    {
        _context.BankAccounts.Add(bankAccount);
        return _context.SaveChangesAsync();
    }

    public async Task<Option<BankAccount>> GetAsync(BankAccountId bankAccountId)
    {
        var result = await _context
            .BankAccounts
            .SingleOrDefaultAsync(x => x.Id == bankAccountId);

        return result == null ? Option<BankAccount>.None : Option<BankAccount>.Some(result);
    }

    public Task<BankAccount?> GetWithTransactionsAsync(BankAccountId bankAccountId)
    {
        return _context
            .BankAccounts
            .Include(x => x.Transactions)
            .SingleOrDefaultAsync(x => x.Id == bankAccountId);
    }

    public async Task<BankAccount> UpdateAsync(BankAccount bankAccount)
    {
        _context.BankAccounts.Update(bankAccount);
        await _context.SaveChangesAsync();
        return bankAccount;
    }
    
    public Option<BankAccount> Update(BankAccount bankAccount)
    {
        _context.BankAccounts.Update(bankAccount);
        return bankAccount;
    }

    public async Task<BankAccount> SaveChangesAsync(BankAccount bankAccount)
    {
        await _context.SaveChangesAsync();
        return bankAccount;
    }
}