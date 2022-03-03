namespace EasyFinance.Domain.Accounts;

public interface ICreditCardRepository
{
    void Create(CreditCard creditCard);
    Task<CreditCard?> GetAsync(Guid creditCardId);
    void Update(CreditCard creditCard);
    Task<CreditCard?> GetSettingsAsync(Guid creditCardId);
}