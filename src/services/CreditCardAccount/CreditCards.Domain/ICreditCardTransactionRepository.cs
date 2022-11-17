namespace CreditCards.Domain;

public interface ICreditCardTransactionRepository
{
    Task<List<CreditCardTransaction>> GetAsync(CreditCardId creditCardId, DateTime startDate, DateTime endDate);
    Task RegisterAsync(CreditCardTransaction transaction);
}