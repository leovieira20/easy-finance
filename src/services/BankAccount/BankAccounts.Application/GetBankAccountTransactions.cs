using BankAccounts.Domain.Aggregates.BankAccountTransactionAggregate;
using BankAccounts.Application.Models;
using MediatR;

namespace BankAccounts.Application;

public static class GetBankAccountTransactions
{
    public record Query(Guid BankAccountId) : IRequest<List<BankAccountTransactionDto>>;
    public class Handler : IRequestHandler<Query, List<BankAccountTransactionDto>>
    {
        private readonly IBankAccountTransactionRepository _repository;

        public Handler(IBankAccountTransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BankAccountTransactionDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var transactions = await _repository.GetForBankAccountAsync(new(request.BankAccountId), default, default);
            
            var mappedTransactions = transactions
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