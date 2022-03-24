using System;
using System.Threading.Tasks;
using EasyFinance.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

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
        _dbContext.SaveChanges();
    }
    
    public Task<CreditCard?> GetAsync(CreditCardId creditCardId)
    {
        return _dbContext
            .CreditCards
            .Include(x => x.Settings)
            .SingleOrDefaultAsync(x => x.Id == creditCardId);
    }

    public void Update(CreditCard creditCard)
    {
        _dbContext.CreditCards.Update(creditCard);
        _dbContext.SaveChanges();
    }

    public Task<CreditCard?> GetSettingsAsync(Guid creditCardId)
    {
        return _dbContext
            .CreditCards
            .Include(x => x.Settings)
            .SingleOrDefaultAsync(x => x.Id.Value == creditCardId);
    }
}