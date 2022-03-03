using MediatR;

namespace EasyFinance.Application.BankAccountTransactionCommands.RegisterDepositToBankAccount;

public record RegisterDepositToBankAccountCommand(Guid BankAccountId, decimal Amount, DateTime date) : IRequest<BankAccountSummaryDto>;