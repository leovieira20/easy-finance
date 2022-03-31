using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.CreditCardCommands.Overview;

class GetCreditCardOverviewCommandHandler : IRequestHandler<GetCreditCardOverviewCommand, IEnumerable<CreditCardMonthlyBreakdownDto>>
{
    private readonly ICreditCardRepository _creditCardRepository;
    private readonly ICreditCardTransactionRepository _transactionRepository;

    public GetCreditCardOverviewCommandHandler(ICreditCardRepository creditCardRepository, ICreditCardTransactionRepository transactionRepository)
    {
        _creditCardRepository = creditCardRepository;
        _transactionRepository = transactionRepository;
    }
    
    public async Task<IEnumerable<CreditCardMonthlyBreakdownDto>> Handle(GetCreditCardOverviewCommand request, CancellationToken cancellationToken)
    {
        var creditCard = await _creditCardRepository.GetWithSettingsAsync(request.CreditCardId);
        
        // TODO add null check for credit card
        var defaultPayment = creditCard!.Settings.DefaultPaymentAmount;
        
        var transactions = await _transactionRepository.GetAsync(request.CreditCardId, request.StartDate, request.EndDate);
        var groupedTransactions = transactions
            .GroupBy(x => new { x.TransactionDate.Year, x.TransactionDate.Month })
            .ToList();

        var overviews = new List<CreditCardMonthlyBreakdownDto>();

        var forecastBalance = 0m;
        var currentDate = DateTime.UtcNow;
        foreach (var monthlyTransactions in groupedTransactions)
        {
            currentDate = new DateTime(monthlyTransactions.Key.Year, monthlyTransactions.Key.Month, 1);
            
            var realBalance = monthlyTransactions.Sum(x => x.TransactionAmount);
            forecastBalance = realBalance - defaultPayment;
            
            overviews.Add(new CreditCardMonthlyBreakdownDto
            {
                Date = currentDate,
                Balance = realBalance,
                ForecastBalance = forecastBalance
            });
        }

        if (forecastBalance == 0)
            return overviews;
        
        while (forecastBalance > 0)
        {
            forecastBalance -= defaultPayment;
            forecastBalance = forecastBalance < 0 ? 0 : forecastBalance;
            
            currentDate = currentDate.AddMonths(1);
            
            overviews.Add(new CreditCardMonthlyBreakdownDto
            {
                Date = currentDate,
                Balance = forecastBalance,
                ForecastBalance = forecastBalance
            });
        }

        return overviews;
    }
}