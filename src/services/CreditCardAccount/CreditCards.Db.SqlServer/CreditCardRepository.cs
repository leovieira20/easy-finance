using CreditCards.Domain;
using CreditCards.Db.SqlServer.EF;
using Microsoft.EntityFrameworkCore;

namespace CreditCards.Db.SqlServer;

class CreditCardRepository : ICreditCardRepository
{
    private readonly CreditCardsDbContext _context;

    public CreditCardRepository(CreditCardsDbContext context)
    {
        _context = context;
    }
    
    public void Create(CreditCard creditCard)
    {
        _context
            .CreditCards
            .Add(creditCard);
        
        _context.SaveChanges();
    }

    public Task<CreditCard?> GetAsync(CreditCardId creditCardId)
    {
        return _context
            .CreditCards
            .SingleOrDefaultAsync(x => x.Id == creditCardId);
    }

    public void Update(CreditCard creditCard)
    {
        _context
            .CreditCards
            .Update(creditCard);

        _context.SaveChanges();
    }

    public Task<CreditCard?> GetSettingsAsync(CreditCardId creditCardId)
    {
        return _context
            .CreditCards
            .Include(x => x.Settings)
            .SingleOrDefaultAsync(x => x.Id == creditCardId);
    }

    public Task<CreditCard?> GetWithSettingsAsync(CreditCardId creditCardId)
    {
        return _context
            .CreditCards
            .Include(x => x.Settings)
            .SingleOrDefaultAsync(x => x.Id == creditCardId);
    }
}