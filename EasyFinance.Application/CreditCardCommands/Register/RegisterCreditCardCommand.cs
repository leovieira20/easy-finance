using MediatR;

namespace EasyFinance.Application.CreditCardCommands.Register;

public record RegisterCreditCardCommand(string cardName) : IRequest<CreditCardDto>;