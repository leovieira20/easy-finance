using CreditCards.Domain;
using CreditCards.Application.Models;
using MediatR;

namespace CreditCards.Application;

public static class GetCreditCardOverview
{
    public record Query(CreditCardId CreditCardId, DateTime StartDate, DateTime EndDate) : IRequest<IEnumerable<CreditCardMonthlyBreakdownDto>>;
    class Handler : IRequestHandler<Query, IEnumerable<CreditCardMonthlyBreakdownDto>>
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly ICreditCardTransactionRepository _transactionRepository;

        public Handler(ICreditCardRepository creditCardRepository,
            ICreditCardTransactionRepository transactionRepository)
        {
            _creditCardRepository = creditCardRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<CreditCardMonthlyBreakdownDto>> Handle(Query request,
            CancellationToken cancellationToken)
        {
            var creditCard = await _creditCardRepository.GetWithSettingsAsync(request.CreditCardId);

            // TODO add null check for credit card
            var defaultPayment = creditCard!.Settings.DefaultPaymentAmount;

            var transactions =
                await _transactionRepository.GetAsync(request.CreditCardId, request.StartDate, request.EndDate);
            var groupedTransactions = transactions.GroupBy(x => new { x.Date.Year, x.Date.Month })
                .ToList();

            var overviews = new List<CreditCardMonthlyBreakdownDto>();

            var overallBalance = 0m;
            var forecastBalance = 0m;
            var currentDate = DateTime.UtcNow;

            foreach (var monthlyTransactions in groupedTransactions)
            {
                currentDate = new(monthlyTransactions.Key.Year, monthlyTransactions.Key.Month, 1);

                var sumOfExpenses = monthlyTransactions
                    .Where(x => x.Type == CreditCardTransactionType.Expense)
                    .Sum(x => x.CalculationAmount);

                var sumOfPayments = monthlyTransactions
                    .Where(x => x.Type == CreditCardTransactionType.Payment)
                    .Sum(x => x.CalculationAmount);

                overallBalance += sumOfExpenses;
                forecastBalance = sumOfExpenses - defaultPayment;

                overviews.Add(new()
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

                overviews.Add(new()
                {
                    Date = currentDate,
                    MonthBalance = forecastBalance,
                    ForecastBalance = forecastBalance
                });
            }

            return overviews;
        }
    }
}