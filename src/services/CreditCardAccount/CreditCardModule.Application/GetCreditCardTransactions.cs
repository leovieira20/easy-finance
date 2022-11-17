using CreditCardModule.Domain;
using MediatR;

namespace CreditCardModule.Application;

public static class GetCreditCardTransactions
{
    public record Query(Guid CreditCardId, DateTime StartDate, DateTime EndDate) : IRequest<IEnumerable<CreditCardTransaction>>;
    public class Handler : IRequestHandler<Query, IEnumerable<CreditCardTransaction>>
    {
        private readonly ICreditCardTransactionRepository _repository;

        public Handler(ICreditCardTransactionRepository repository)
        {
            _repository = repository;
        }
    
        public async Task<IEnumerable<CreditCardTransaction>> Handle(Query request, CancellationToken cancellationToken)
        {
            var transactions = await _repository.GetAsync(new CreditCardId(request.CreditCardId), request.StartDate, request.EndDate);

            return transactions;
        }
    }    
}
