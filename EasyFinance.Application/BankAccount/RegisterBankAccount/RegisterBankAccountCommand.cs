using MediatR;

namespace EasyFinance.Application.RegisterBankAccount;

public record RegisterBankAccountCommand(string BankAccountName) : IRequest<BankAccountDto>;