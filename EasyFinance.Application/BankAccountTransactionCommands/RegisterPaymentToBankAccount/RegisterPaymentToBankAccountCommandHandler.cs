using EasyFinance.Application.BankAccountTransactionCommands.RegisterDepositToBankAccount;
using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.BankAccountTransactionCommands.RegisterPaymentToBankAccount;

public class RegisterPaymentToBankAccountCommandHandler : IRequestHandler<RegisterPaymentToBankAccountCommand, BankAccountSummaryDto>
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

        bankAccount.RegisterPayment(request.Amount, request.date);

        await _repository.Update(bankAccount);

        return new BankAccountSummaryDto
        {
            Balance = bankAccount.Balance
        };
    }
}