using BankAccountModule.Domain;
using MediatR;

namespace BankAccountModule.Application.RegisterBankAccount;

class RegisterBankAccountCommandHandler : IRequestHandler<RegisterBankAccountCommand, BankAccountDto>
{
    private readonly IBankAccountRepository _repository;

    public RegisterBankAccountCommandHandler(IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<BankAccountDto> Handle(RegisterBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = BankAccount.Create(request.BankAccountName);

        await _repository.CreateAsync(bankAccount);
        
        return new BankAccountDto
        {
            Id = bankAccount.Id.Value,
            Name = bankAccount.Name,
            Status = bankAccount.Status
        };
    }
}