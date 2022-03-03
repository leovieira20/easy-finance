using MediatR;

namespace EasyFinance.Application.BankAccountCommands.RegisterBankAccount;

public record RegisterBankAccountCommand(string BankAccountName) : IRequest<BankAccountDto>;