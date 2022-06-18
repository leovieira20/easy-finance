using BankAccountModule.Domain.Events;

namespace BankAccountModule.Domain;

public partial record BankAccount {
    protected override BankAccount Apply(AggregateEvent @event)
    {
        return @event switch
        {
            BankAccountCreated created => When(created),
            BankAccountDepositRegistered registered => When(registered),
            BankAccountExpenseRegistered registered => When(registered),
            _ => throw new ArgumentException()
        };
    }

    private BankAccount When(BankAccountCreated @event)
    {
        return this with
        {
            Id = new BankAccountId(@event.Id),
            Name = @event.Name,
            Status = BankAccountStatus.Enabled
        };
    }

    private BankAccount When(BankAccountDepositRegistered @event)
    {
        var transactions = Transactions.Add(new BankAccountTransaction(@event.EventDate, 
            BankAccountTransactionType.Credit, 
            @event.Amount, 
            @event.Amount, 
            @event.Description));

        return this with
        {
            Transactions = transactions
        };
    }

    private BankAccount When(BankAccountExpenseRegistered @event)
    {
        var transactions = Transactions.Add(new BankAccountTransaction(@event.EventDate, 
            BankAccountTransactionType.Credit, 
            @event.Amount, 
            -@event.Amount, 
            @event.Description));
        
        return this with
        {
            Transactions = transactions
        };
    }
}