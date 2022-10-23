using CreditCardModule.Domain;
using MediatR;

namespace CreditCardModule.Application.SetDefaultPaymentAmount;

public record SetCreditCardDefaultPaymentAmountCommand(Guid creditCardId, decimal amount) : IRequest<CreditCardSettings>;