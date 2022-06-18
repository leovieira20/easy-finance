using BankAccountModule.Domain;
using BankAccountModule.Domain.Repositories;
using MediatR;

namespace BankAccountModule.Application.RegisterDepositToBankAccount;

class RegisterDepositToBankAccountCommandHandler : IRequestHandler<RegisterDepositToBankAccountCommand, BankAccountSummaryDto>
{
    private readonly IBankAccountRepository _repository;

    public RegisterDepositToBankAccountCommandHandler(IBankAccountRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<BankAccountSummaryDto> Handle(RegisterDepositToBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _repository.GetAsync(new BankAccountId(request.BankAccountId));
        
        return await bankAccount
            .Some(x => RegisterCreditAsync(x, request))
            .None(Task.FromResult(new BankAccountSummaryDto()));
    }

    private async Task<BankAccountSummaryDto> RegisterCreditAsync(BankAccount bankAccount, RegisterDepositToBankAccountCommand request)
    {
        bankAccount = bankAccount.RegisterDeposit(request.date, request.Amount, string.Empty);

        await _repository.Update(bankAccount);

        return new BankAccountSummaryDto
        {
            Balance = bankAccount.Balance
        };
    }
}