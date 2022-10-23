using CreditCardModule.Domain;
using MediatR;

namespace CreditCardModule.Application.SetThreshold;

public record SetCreditCardThresholdCommand(Guid creditCardId, decimal amount) : IRequest<CreditCardSettings>;