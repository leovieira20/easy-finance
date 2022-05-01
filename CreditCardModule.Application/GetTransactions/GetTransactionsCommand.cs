using CreditCardModule.Domain;
using MediatR;

namespace CreditCardModule.Application.GetTransactions;

public record GetTransactionsCommand(Guid CreditCardId, DateTime StartDate, DateTime EndDate) : IRequest<IEnumerable<CreditCardTransaction>>;