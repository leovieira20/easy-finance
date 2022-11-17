namespace BankAccounts.Domain.Aggregates.BankAccountTransactionAggregate;

public interface IBankAccountTransactionRepository
{
    Task<List<BankAccountTransaction>> GetForBankAccountAsync(BankAccountAggregate.BankAccountId bankAccountId,
        DateTime startDate,
        DateTime endDate);
}