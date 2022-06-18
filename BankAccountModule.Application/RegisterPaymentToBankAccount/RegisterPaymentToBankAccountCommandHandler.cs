using BankAccountModule.Application.RegisterDepositToBankAccount;
using BankAccountModule.Domain;
using BankAccountModule.Domain.Repositories;
using LanguageExt;
using MediatR;

namespace BankAccountModule.Application.RegisterPaymentToBankAccount;

class RegisterPaymentToBankAccountCommandHandler : IRequestHandler<RegisterPaymentToBankAccountCommand, BankAccountSummaryDto>
{
    private readonly IBankAccountRepository _repository;

    public RegisterPaymentToBankAccountCommandHandler(IBankAccountRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<BankAccountSummaryDto> Handle(RegisterPaymentToBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _repository.GetAsync(new BankAccountId(request.BankAccountId));

        return await bankAccount
            .Some(x => RegisterDebitAsync(x, request))
            .None(Task.FromResult(new BankAccountSummaryDto()));
    }

    private async Task<BankAccountSummaryDto> RegisterDebitAsync(BankAccount bankAccount, RegisterPaymentToBankAccountCommand request)
    {
        bankAccount.RegisterExpense(request.date, request.Amount, string.Empty);

        await _repository.Update(bankAccount);

        return new BankAccountSummaryDto
        {
            Balance = bankAccount.Balance
        };
    }
}