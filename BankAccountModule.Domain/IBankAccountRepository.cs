namespace BankAccountModule.Domain;

public interface IBankAccountRepository
{
    Task CreateAsync(BankAccount bankAccount);
    Task<BankAccount?> GetAsync(BankAccountId bankAccountId);
    Task<BankAccount?> GetWithTransactionsAsync(BankAccountId bankAccountId);
    Task Update(BankAccount bankAccount);
}