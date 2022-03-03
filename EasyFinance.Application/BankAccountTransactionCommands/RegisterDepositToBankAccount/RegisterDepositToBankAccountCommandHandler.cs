using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.BankAccountTransactionCommands.RegisterDepositToBankAccount;

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
        if (bankAccount == null)
            return new BankAccountSummaryDto();

        bankAccount.RegisterDeposit(request.Amount, request.date);

        await _repository.Update(bankAccount);

        return new BankAccountSummaryDto
        {
            Balance = bankAccount.Balance
        };
    }
}