using EasyFinance.Domain.Accounts;

namespace EasyFinance.Db.SqlServer;

public class CreditCardRepository : ICreditCardRepository
{
    public void Create(CreditCard creditCard)
    {
    }

    public Task<CreditCard?> GetAsync(Guid creditCardId)
    {
        throw new NotImplementedException();
    }

    public void Update(CreditCard creditCard)
    {
        throw new NotImplementedException();
    }

    public Task<CreditCard?> GetSettingsAsync(Guid creditCardId)
    {
        throw new NotImplementedException();
    }
}