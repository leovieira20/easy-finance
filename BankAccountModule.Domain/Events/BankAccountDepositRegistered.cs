namespace BankAccountModule.Domain.Events;

public record BankAccountDepositRegistered(Guid Id, DateTime EventDate, decimal Amount, string Description) 
    : BankAccountEvent(Id, EventDate);