using MediatR;

namespace EasyFinance.Application.BankAccountTransaction.RegisterDepositToBankAccount;

public record RegisterDepositToBankAccountCommand(Guid BankAccountId, decimal Amount, DateTime date) : IRequest<BankAccountSummaryDto>;