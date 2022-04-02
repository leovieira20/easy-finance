using BankAccountModule.Application.RegisterDepositToBankAccount;
using BankAccountModule.Domain;
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
        if (bankAccount == null)
            return new BankAccountSummaryDto();

        bankAccount.RegisterDebit(request.date, request.Amount, string.Empty);

        await _repository.Update(bankAccount);

        return new BankAccountSummaryDto
        {
            Balance = bankAccount.Balance
        };
    }
}