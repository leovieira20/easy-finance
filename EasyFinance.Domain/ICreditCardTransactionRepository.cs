using EasyFinance.Domain.Accounts;

namespace EasyFinance.Domain;

public interface ICreditCardTransactionRepository
{
    Task<List<Transaction>> GetAsync(Guid requestCreditCardId, DateTime requestStartDate, DateTime requestEndDate);
}