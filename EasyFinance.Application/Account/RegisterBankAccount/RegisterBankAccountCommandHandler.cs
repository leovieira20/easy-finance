using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.Account.RegisterBankAccount;

public class RegisterBankAccountCommandHandler : IRequestHandler<RegisterBankAccountCommand, BankAccount>
{
    private readonly IBankAccountRepository _repository;

    public RegisterBankAccountCommandHandler(IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<BankAccount> Handle(RegisterBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = BankAccount.Create(request.BankAccountName);

        await _repository.CreateAsync(bankAccount);
        
        return bankAccount;
    }
}