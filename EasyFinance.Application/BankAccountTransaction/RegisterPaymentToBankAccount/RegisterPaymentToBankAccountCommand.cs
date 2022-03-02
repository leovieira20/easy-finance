using MediatR;

namespace EasyFinance.Application.RegisterDepositToBankAccount;

public record RegisterPaymentToBankAccountCommand(Guid BankAccountId, decimal Amount, DateTime date) : IRequest<BankAccountSummaryDto>;