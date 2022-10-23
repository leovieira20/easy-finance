namespace CreditCardModule.Domain;

public interface ICreditCardRepository
{
    void Create(CreditCard creditCard);
    Task<CreditCard?> GetAsync(CreditCardId creditCardId);
    void Update(CreditCard creditCard);
    Task<CreditCard?> GetSettingsAsync(CreditCardId creditCardId);
    Task<CreditCard?> GetWithSettingsAsync(CreditCardId creditCardId);
}