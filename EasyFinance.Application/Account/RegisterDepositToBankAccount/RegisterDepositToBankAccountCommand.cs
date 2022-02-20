using MediatR;

namespace EasyFinance.Application.Account.RegisterDepositToBankAccount;

public record RegisterDepositToBankAccountCommand(Guid BankAccountId, decimal Amount) : IRequest<BankAccountSummaryDto>;