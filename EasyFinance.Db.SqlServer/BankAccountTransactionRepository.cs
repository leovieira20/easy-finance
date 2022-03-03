using EasyFinance.Domain.Accounts;

namespace EasyFinance.Db.SqlServer;

class BankAccountTransactionRepository : IBankAccountTransactionRepository

{
    public Task<List<BankAccountTransaction>> GetForBankAccountAsync(BankAccountId bankAccountId, DateTime startDate,
        DateTime endDate)
    {
        return Task.FromResult(new List<BankAccountTransaction>());
    }
}