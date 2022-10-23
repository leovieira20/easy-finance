namespace CreditCardModule.Api.Models.Input;

public record GetTransactionsRequest(Guid CreditCardId, DateTime StartDate, DateTime EndDate);