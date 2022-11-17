using LanguageExt;

namespace BankAccounts.Domain.Aggregates.BankAccountAggregate;

public interface IBankAccountRepository
{
    Task CreateAsync(BankAccount bankAccount);
    Task<Option<BankAccount>> GetAsync(BankAccountId bankAccountId);
    Task<BankAccount?> GetWithTransactionsAsync(BankAccountId bankAccountId);
    Task<BankAccount> UpdateAsync(BankAccount bankAccount);
    Option<BankAccount> Update(BankAccount bankAccount);
    Task<BankAccount> SaveChangesAsync(BankAccount bankAccount);
}