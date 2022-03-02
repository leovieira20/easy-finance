using EasyFinance.Domain.Accounts;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Db;

public class InMemoryEfCreditCardRepository : ICreditCardRepository
{
    private readonly ApplicationDbContext _dbContext;

    public InMemoryEfCreditCardRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Create(CreditCard creditCard)
    {
        _dbContext.CreditCards.Add(creditCard);
    }
}