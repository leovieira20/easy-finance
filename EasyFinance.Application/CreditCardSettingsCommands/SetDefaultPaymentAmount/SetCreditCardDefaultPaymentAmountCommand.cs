using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.CreditCardSettingsCommands.SetDefaultPaymentAmount;

public record SetCreditCardDefaultPaymentAmountCommand(Guid creditCardId, decimal amount) : IRequest<CreditCardSettings>;