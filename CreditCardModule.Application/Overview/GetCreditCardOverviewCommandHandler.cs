using CreditCardModule.Domain;
using MediatR;

namespace CreditCardModule.Application.Overview;

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
        var groupedTransactions = Enumerable.GroupBy(transactions, x => new { x.Date.Year, x.Date.Month })
            .ToList();

        var overviews = new List<CreditCardMonthlyBreakdownDto>();

        var overallBalance = 0m;
        var forecastBalance = 0m;
        var currentDate = DateTime.UtcNow;

        foreach (var monthlyTransactions in groupedTransactions)
        {
            currentDate = new DateTime(monthlyTransactions.Key.Year, monthlyTransactions.Key.Month, 1);
            
            var sumOfExpenses = monthlyTransactions
                .Where(x => x.Type == CreditCardTransactionType.Expense)
                .Sum(x => x.CalculationAmount);
            
            var sumOfPayments = monthlyTransactions
                .Where(x => x.Type == CreditCardTransactionType.Payment)
                .Sum(x => x.CalculationAmount);
            
            overallBalance += sumOfExpenses;
            forecastBalance = sumOfExpenses - defaultPayment;
            
            overviews.Add(new CreditCardMonthlyBreakdownDto
            {
                Date = currentDate,
                OverallBalance = overallBalance,
                MonthBalance = sumOfExpenses,
                ForecastBalance = forecastBalance,
                Expenses = sumOfExpenses,
                Payments = sumOfPayments,
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
                MonthBalance = forecastBalance,
                ForecastBalance = forecastBalance
            });
        }

        return overviews;
    }
}