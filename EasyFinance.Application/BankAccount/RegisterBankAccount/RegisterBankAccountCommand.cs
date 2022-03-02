using MediatR;

namespace EasyFinance.Application.BankAccount.RegisterBankAccount;

public record RegisterBankAccountCommand(string BankAccountName) : IRequest<BankAccountDto>;