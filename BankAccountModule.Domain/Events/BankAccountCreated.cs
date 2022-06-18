namespace BankAccountModule.Domain.Events;

public record BankAccountCreated(Guid Id, DateTime EventDate, string Name) 
    : BankAccountEvent(Id, EventDate);