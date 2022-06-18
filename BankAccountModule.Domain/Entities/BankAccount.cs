using System.Collections.Immutable;
using Ardalis.GuardClauses;
using BankAccountModule.Domain.Events;

namespace BankAccountModule.Domain;

public partial record BankAccount : AggregateBase<BankAccount>
{
    public static BankAccount CreateWithName(string bankAccountName)
    {
        Guard.Against.NullOrWhiteSpace(bankAccountName, nameof(bankAccountName));
        
        var bankAccount = new BankAccount();

        var @event = new BankAccountCreated(Guid.NewGuid(), DateTime.UtcNow, bankAccountName);
        return bankAccount.Apply(@event);
    }

    public static BankAccount Create(BankAccountId id, string bankAccountName)
    {
        Guard.Against.Null(id, nameof(id));
        Guard.Against.NullOrWhiteSpace(bankAccountName, nameof(bankAccountName));
        
        return new BankAccount
        {
            Id = id,
            Status = BankAccountStatus.Enabled,
            Name = bankAccountName
        };
    }
    
    public static BankAccount Create(params BankAccountEvent[] events)
    {
        return events
            .Aggregate(new BankAccount(), (account, @event) => account.Apply(@event));
    }

    private BankAccount()
    {
        Id = BankAccountId.New();
    }
    
    public BankAccount RegisterDeposit(DateTime date, decimal amount, string description)
    {
        var @event = new BankAccountDepositRegistered(Id.Value, date, amount, description);
        return Apply(@event);
    }

    public BankAccount RegisterExpense(DateTime date, decimal amount, string description)
    {
        var @event = new BankAccountExpenseRegistered(Id.Value, date, amount, description);
        return Apply(@event);
    }

    public BankAccountId Id { get; private init; }
    public string Status { get; private init; } = null!;
    public string Name { get; private init; } = null!;
    public decimal Balance => Transactions.Sum(x => x.CalculationAmount);
    public ImmutableList<BankAccountTransaction> Transactions { get; private init; } = ImmutableList<BankAccountTransaction>.Empty;
}