using EasyFinance.Domain.Accounts;

namespace EasyFinance.Db.SqlServer;

public class BankAccountRepository : IBankAccountRepository
{
    public Task CreateAsync(BankAccount bankAccount)
    {
        return Task.CompletedTask;
    }

    public Task<BankAccount?> GetAsync(BankAccountId bankAccountId)
    {
        return Task.FromResult(BankAccount.Create(Guid.NewGuid().ToString()))!;
    }

    public Task Update(BankAccount bankAccount)
    {
        return Task.CompletedTask;
    }
}