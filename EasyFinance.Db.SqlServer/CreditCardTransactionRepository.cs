using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;

namespace EasyFinance.Db.SqlServer;

class CreditCardTransactionRepository : ICreditCardTransactionRepository
{
    public Task<List<Transaction>> GetAsync(Guid requestCreditCardId, DateTime requestStartDate, DateTime requestEndDate)
    {
        throw new NotImplementedException();
    }
}