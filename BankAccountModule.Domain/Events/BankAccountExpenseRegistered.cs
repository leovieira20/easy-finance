namespace BankAccountModule.Domain.Events;

public record BankAccountExpenseRegistered(Guid Id, DateTime EventDate, decimal Amount, string Description) 
    : BankAccountEvent(Id, EventDate);