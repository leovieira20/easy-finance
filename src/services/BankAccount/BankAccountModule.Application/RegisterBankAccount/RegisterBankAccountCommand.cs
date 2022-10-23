using MediatR;

namespace BankAccountModule.Application.RegisterBankAccount;

public record RegisterBankAccountCommand(string BankAccountName) : IRequest<BankAccountDto>;