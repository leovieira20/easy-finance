using CreditCardModule.Domain;
using MediatR;

namespace CreditCardModule.Application.SetLimit;

public record SetCreditCardLimitCommand(Guid creditCardId, decimal amount) : IRequest<CreditCardSettings>;