using MediatR;

namespace BankAccountModule.Application.RegisterDepositToBankAccount;

public record RegisterDepositToBankAccountCommand(Guid BankAccountId, decimal Amount, DateTime date) : IRequest<BankAccountSummaryDto>;