using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.CreditCardSettingsCommands.SetThreshold;

public record SetCreditCardThresholdCommand(Guid creditCardId, decimal amount) : IRequest<CreditCardSettings>;