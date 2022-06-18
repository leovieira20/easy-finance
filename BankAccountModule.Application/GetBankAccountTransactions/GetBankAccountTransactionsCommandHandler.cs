using BankAccountModule.Domain;
using BankAccountModule.Domain.Repositories;
using MediatR;

namespace BankAccountModule.Application.GetBankAccountTransactions;

class GetBankAccountTransactionsCommandHandler : IRequestHandler<GetBankAccountTransactionsCommand, List<BankAccountTransactionDto>>
{
    private readonly IBankAccountRepository _repository;

    public GetBankAccountTransactionsCommandHandler(IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BankAccountTransactionDto>> Handle(GetBankAccountTransactionsCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _repository.GetWithTransactionsAsync(new BankAccountId(request.BankAccountId));
        if (bankAccount == null)
            return new List<BankAccountTransactionDto>();

        var mappedTransactions = bankAccount
            .Transactions
            .OrderBy(x => x.Date)
            .Select(x => new BankAccountTransactionDto
        {
            Date = x.Date,
            Amount = x.Amount,
            Description = x.Description
        });

        return mappedTransactions.ToList();
    }
}