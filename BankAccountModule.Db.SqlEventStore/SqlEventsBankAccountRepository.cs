using BankAccountModule.Domain;
using BankAccountModule.Domain.Events;
using BankAccountModule.Domain.Repositories;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace BankAccountModule.Db.SqlEventStore;

public class SqlEventsBankAccountRepository : IBankAccountRepository
{
    private readonly BankAccountEventDbContext _dbContext;

    public SqlEventsBankAccountRepository(BankAccountEventDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task CreateAsync(BankAccount bankAccount)
    {
        var events = bankAccount.GetUncommittedEvents();

        foreach (var @event in events)
        {
            _dbContext.BankAccountEvents.Add((BankAccountEvent)@event);
        }

        return _dbContext.SaveChangesAsync();
    }

    public async Task<Option<BankAccount>> GetAsync(BankAccountId bankAccountId)
    {
        var events = await _dbContext.BankAccountEvents
            .Where(x => x.Id == bankAccountId.Value)
            .ToListAsync();

        if (!events.Any())
        {
            return Option<BankAccount>.None;
        }

        return BankAccount.Create(events.ToArray());
    }

    public async Task<BankAccount?> GetWithTransactionsAsync(BankAccountId bankAccountId)
    {
        var events = await _dbContext.BankAccountEvents
            .Where(x => x.Id == bankAccountId.Value)
            .ToListAsync();

        if (!events.Any())
        {
            return null;
        }
        
        return BankAccount.Create(events.ToArray());
    }

    public Task Update(BankAccount bankAccount)
    {
        throw new NotImplementedException();
    }
}