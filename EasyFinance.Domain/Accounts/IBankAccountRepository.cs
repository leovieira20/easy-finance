namespace EasyFinance.Domain.Accounts;

public interface IBankAccountRepository
{
    Task CreateAsync(BankAccount bankAccount);
    Task<BankAccount> GetAsync(BankAccountId bankAccountId);
}