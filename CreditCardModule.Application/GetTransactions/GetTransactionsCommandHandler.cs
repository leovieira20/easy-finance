using CreditCardModule.Domain;
using MediatR;

namespace CreditCardModule.Application.GetTransactions;

public class GetTransactionsCommandHandler : IRequestHandler<GetTransactionsCommand, IEnumerable<CreditCardTransaction>>
{
    private readonly ICreditCardTransactionRepository _repository;

    public GetTransactionsCommandHandler(ICreditCardTransactionRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<CreditCardTransaction>> Handle(GetTransactionsCommand request, CancellationToken cancellationToken)
    {
        var transactions = await _repository.GetAsync(new CreditCardId(request.CreditCardId), request.StartDate, request.EndDate);

        return transactions;
    }
}