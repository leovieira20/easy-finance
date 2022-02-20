using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.Account.ShowBankAccountTransactions;

public class ShowBankAccountTransactionHistoryCommandHandler : IRequestHandler<ShowBankAccountTransactionHistoryCommand, List<BankAccountTransactionDto>>
{
    private readonly IBankAccountRepository _repository;

    public ShowBankAccountTransactionHistoryCommandHandler(IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BankAccountTransactionDto>> Handle(ShowBankAccountTransactionHistoryCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _repository.GetAsync(new BankAccountId(request.BankAccountId));
        if (bankAccount == null)
            return new List<BankAccountTransactionDto>();

        var mappedTransactions = bankAccount.Transactions.Select(x => new BankAccountTransactionDto
        {
            Amount = x.Amount
        });

        return mappedTransactions.ToList();
    }
}