namespace BankAccountModule.Domain.Events;

public abstract record BankAccountEvent(Guid Id, DateTime EventDate) : AggregateEvent(Id);