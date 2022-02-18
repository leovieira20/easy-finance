using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.Account.AddFundsToBankAccount;

public class AddFundsToBankAccountCommandHandler : IRequestHandler<AddFundsToBankAccountCommand, BankAccountSummaryDTO>
{
    private readonly IBankAccountRepository _repository;

    public AddFundsToBankAccountCommandHandler(IBankAccountRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<BankAccountSummaryDTO> Handle(AddFundsToBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _repository.GetAsync(new BankAccountId(request.BankAccountId));

        bankAccount.AddFunds(request.Amount);

        return new BankAccountSummaryDTO
        {
            Balance = bankAccount.Balance
        };
    }
}