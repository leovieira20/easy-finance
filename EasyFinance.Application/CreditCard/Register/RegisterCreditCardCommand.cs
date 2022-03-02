using MediatR;

namespace EasyFinance.Application.Register;

public record RegisterCreditCardCommand(string cardName) : IRequest<CreditCardDto>;