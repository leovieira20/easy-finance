using BankAccountModule.Domain;
using BankAccountModule.Domain.Repositories;
using Db.SqlServer;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace BankAccountModule.Db.SqlServer;

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

    public Task Update(BankAccount bankAccount)
    {
        _context.BankAccounts.Update(bankAccount);
        return _context.SaveChangesAsync();
    }
}