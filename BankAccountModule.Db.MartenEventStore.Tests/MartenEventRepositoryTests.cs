using BankAccountModule.Domain;
using FluentAssertions;
using LanguageExt.UnsafeValueAccess;

namespace BankAccountModule.Db.MartenEventStore.Tests;

public class MartenEventRepositoryTests
{
    [Fact]
    public async Task CanPersistAndRetrieve()
    {
        var repository = new MartenEventRepository();

        var bankAccountName = Guid.NewGuid().ToString();
        var bankAccount = BankAccount.CreateWithName(bankAccountName);

        await repository.CreateAsync(bankAccount);

        var stored = await repository.GetAsync(bankAccount.Id);

        stored.ValueUnsafe().Name.Should().Be(bankAccountName);
    }
}