using BankAccountModule.Application.Models;
using BankAccountModule.Domain;
using MediatR;

namespace BankAccountModule.Application;

public static class GetBankAccountTransactions
{
    public record Query(Guid BankAccountId) : IRequest<List<BankAccountTransactionDto>>;
    class Handler : IRequestHandler<Query, List<BankAccountTransactionDto>>
    {
        private readonly IBankAccountRepository _repository;

        public Handler(IBankAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BankAccountTransactionDto>> Handle(Query request, CancellationToken cancellationToken)
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
}