using BankAccountModule.Application.RegisterDepositToBankAccount;
using MediatR;

namespace BankAccountModule.Application.RegisterPaymentToBankAccount;

public record RegisterPaymentToBankAccountCommand(Guid BankAccountId, decimal Amount, DateTime date) : IRequest<BankAccountSummaryDto>;