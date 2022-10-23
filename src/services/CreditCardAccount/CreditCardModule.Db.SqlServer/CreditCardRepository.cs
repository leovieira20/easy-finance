using CreditCardModule.Domain;
using Db.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace CreditCardModule.Db.SqlServer;

class CreditCardRepository : ICreditCardRepository
{
    private readonly EasyFinanceDbContext _context;

    public CreditCardRepository(EasyFinanceDbContext context)
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