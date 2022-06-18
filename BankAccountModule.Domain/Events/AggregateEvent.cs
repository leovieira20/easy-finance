namespace BankAccountModule.Domain.Events;

public abstract record AggregateEvent(Guid AggregateId);