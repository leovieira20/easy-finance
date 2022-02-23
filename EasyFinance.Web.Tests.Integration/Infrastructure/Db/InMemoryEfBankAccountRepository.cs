using System.Threading.Tasks;
using EasyFinance.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Db;

public class InMemoryEfBankAccountRepository : IBankAccountRepository
{
    private readonly ApplicationDbContext _dbContext;

    public InMemoryEfBankAccountRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateAsync(BankAccount bankAccount)
    {
        _dbContext.BankAccounts.Add(bankAccount);
        await _dbContext.SaveChangesAsync();
    }

    public Task<BankAccount?> GetAsync(BankAccountId bankAccountId)
    {
        return _dbContext
            .BankAccounts
            .Include(x => x.Transactions)
            .SingleOrDefaultAsync(x => x.Id == bankAccountId);
    }

    public async Task Update(BankAccount bankAccount)
    {
        _dbContext.BankAccounts.Update(bankAccount);
        await _dbContext.SaveChangesAsync();
    }
}