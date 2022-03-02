using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.RegisterBankAccount;

public class RegisterBankAccountCommandHandler : IRequestHandler<RegisterBankAccountCommand, BankAccountDto>
{
    private readonly IBankAccountRepository _repository;

    public RegisterBankAccountCommandHandler(IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<BankAccountDto> Handle(RegisterBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = Domain.Accounts.BankAccount.Create(request.BankAccountName);

        await _repository.CreateAsync(bankAccount);
        
        return new BankAccountDto
        {
            Id = bankAccount.Id.Value,
            Name = bankAccount.Name,
            Status = bankAccount.Status
        };
    }
}