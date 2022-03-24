using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;

namespace EasyFinance.Db.SqlServer;

class CreditCardTransactionRepository : ICreditCardTransactionRepository
{
    public Task<List<CreditCardTransaction>> GetAsync(CreditCardId requestCreditCardId, DateTime requestStartDate,
        DateTime requestEndDate)
    {
        throw new NotImplementedException();
    }

    public Task RegisterAsync(CreditCardTransaction transaction)
    {
        throw new NotImplementedException();
    }
}