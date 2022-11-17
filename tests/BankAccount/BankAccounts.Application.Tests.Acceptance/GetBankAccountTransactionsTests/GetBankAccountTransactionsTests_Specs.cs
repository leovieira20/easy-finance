using BankAccounts.Application.Models;
using BankAccounts.Domain.Aggregates.BankAccountTransactionAggregate;
using LightBDD.Framework.Parameters;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;

namespace BankAccounts.Application.Tests.Acceptance.GetBankAccountTransactionsTests;

public partial class GetBankAccountTransactionsTests
{
    [Scenario]
    public Task ExistingTransactions()
    {
        var t1 = BankAccountTransaction.CreateDebit(DateTime.UtcNow, 1, Guid.NewGuid().ToString());
        var t2 = BankAccountTransaction.CreateDebit(DateTime.UtcNow.AddSeconds(1), 1, Guid.NewGuid().ToString());

        var exT1 = new BankAccountTransactionDto { Date = t1.Date, Amount = t1.Amount, Description = t1.Description };
        var exT2 = new BankAccountTransactionDto { Date = t2.Date, Amount = t2.Amount, Description = t2.Description };

        return Runner.RunScenarioAsync(
            _ => GivenExistentTransactions(Table.For(t1, t2)),
            _ => WhenActionIsExecuted(),
            _ => ThenTransactionsAreReturned(Table.For(exT1, exT2)));
    }
}