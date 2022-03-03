using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.CreditCardSettingsCommands.SetLimit;

public record SetCreditCardLimitCommand(Guid creditCardId, decimal amount) : IRequest<CreditCardSettings>;