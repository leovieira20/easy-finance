using EasyFinance.Domain.Accounts;

namespace EasyFinance.Infrastructure.Db.Ef;

public class BankAccountRepository : IBankAccountRepository
{
    public Task CreateAsync(BankAccount bankAccount)
    {
        return Task.CompletedTask;
    }

    public Task<BankAccount> GetAsync(BankAccountId bankAccountId)
    {
        return Task.FromResult(BankAccount.Create(Guid.NewGuid().ToString()));
    }
}