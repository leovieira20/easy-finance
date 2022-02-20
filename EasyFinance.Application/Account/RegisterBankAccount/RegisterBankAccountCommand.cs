using MediatR;

namespace EasyFinance.Application.Account.RegisterBankAccount;

public record RegisterBankAccountCommand(string BankAccountName) : IRequest<BankAccountDto>;