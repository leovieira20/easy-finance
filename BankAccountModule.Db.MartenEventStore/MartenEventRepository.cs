using BankAccountModule.Domain;
using BankAccountModule.Domain.Events;
using BankAccountModule.Domain.Repositories;
using LanguageExt;
using Marten;
using Weasel.Core;

namespace BankAccountModule.Db.MartenEventStore;

public class MartenEventRepository : IBankAccountRepository
{
    private DocumentStore _store;

    public MartenEventRepository()
    {
        _store = DocumentStore.For(_ =>
        {
            _.DatabaseSchemaName = "bankaccount";
            _.Connection("host=localhost;port=5432;database=marten_test;user=postgres;password=LeoVC123");

            _.Events.AddEventTypes(new[]
            {
                typeof(BankAccountCreated), 
                typeof(BankAccountDepositRegistered), 
                typeof(BankAccountExpenseRegistered)
            });

            // _.Projections.SelfAggregate<BankAccount>();
        });
        _store.Options.AutoCreateSchemaObjects = AutoCreate.All;
    }

    public async Task CreateAsync(BankAccount bankAccount)
    {
        await using var session = _store.OpenSession();
        session.Events.StartStream<BankAccount>(bankAccount.Id, bankAccount.GetUncommittedEvents());

        await session.SaveChangesAsync();
    }

    public async Task<Option<BankAccount>> GetAsync(BankAccountId bankAccountId)
    {
        await using var session = _store.OpenSession();

        return await session.Events.AggregateStreamAsync<BankAccount>(bankAccountId.Value);
    }

    public Task<BankAccount?> GetWithTransactionsAsync(BankAccountId bankAccountId)
    {
        throw new NotImplementedException();
    }

    public Task Update(BankAccount bankAccount)
    {
        throw new NotImplementedException();
    }
}