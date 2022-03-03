using EasyFinance.Application.BankAccountTransactionCommands.RegisterDepositToBankAccount;
using MediatR;

namespace EasyFinance.Application.BankAccountTransactionCommands.RegisterPaymentToBankAccount;

public record RegisterPaymentToBankAccountCommand(Guid BankAccountId, decimal Amount, DateTime date) : IRequest<BankAccountSummaryDto>;