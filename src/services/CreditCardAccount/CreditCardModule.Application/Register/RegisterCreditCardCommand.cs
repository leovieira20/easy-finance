using MediatR;

namespace CreditCardModule.Application.Register;

public record RegisterCreditCardCommand(string cardName) : IRequest<CreditCardDto>;