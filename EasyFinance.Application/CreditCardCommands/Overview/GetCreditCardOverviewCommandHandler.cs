using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.CreditCardCommands.Overview;

public class GetCreditCardOverviewCommandHandler : IRequestHandler<GetCreditCardOverviewCommand, CreditCardOverviewDto>
{
    private readonly ICreditCardRepository _creditCardRepository;
    private readonly ICreditCardTransactionRepository _transactionRepository;

    public GetCreditCardOverviewCommandHandler(ICreditCardRepository creditCardRepository, ICreditCardTransactionRepository transactionRepository)
    {
        _creditCardRepository = creditCardRepository;
        _transactionRepository = transactionRepository;
    }
    
    public async Task<CreditCardOverviewDto> Handle(GetCreditCardOverviewCommand request, CancellationToken cancellationToken)
    {
        var creditCard = await _creditCardRepository.GetAsync(request.CreditCardId);
        
        var transactions = await _transactionRepository.GetAsync(request.CreditCardId, request.StartDate, request.EndDate);

        return new CreditCardOverviewDto();
    }
}