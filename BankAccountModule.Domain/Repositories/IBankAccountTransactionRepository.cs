namespace BankAccountModule.Domain.Repositories;

public interface IBankAccountTransactionRepository
{
    Task<List<BankAccountTransaction>> GetForBankAccountAsync(BankAccountId bankAccountId,
        DateTime startDate,
        DateTime endDate);
}