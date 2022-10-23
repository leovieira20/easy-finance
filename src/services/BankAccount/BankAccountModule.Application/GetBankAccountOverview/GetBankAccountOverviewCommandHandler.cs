using BankAccountModule.Domain;
using MediatR;

namespace BankAccountModule.Application.GetBankAccountOverview;

class GetBankAccountOverviewCommandHandler : IRequestHandler<GetBankAccountOverviewCommand, List<MonthlyBreakdownDto>>
{
    private readonly IBankAccountTransactionRepository _bankAccountRepository;

    public GetBankAccountOverviewCommandHandler(IBankAccountTransactionRepository bankAccountRepository)
    {
        _bankAccountRepository = bankAccountRepository;
    }
    
    public async Task<List<MonthlyBreakdownDto>> Handle(GetBankAccountOverviewCommand request, CancellationToken cancellationToken)
    {
        var transactions = await _bankAccountRepository
            .GetForBankAccountAsync(request.bankAccountId, request.startDate, request.endDate);

        var breakdowns = new List<MonthlyBreakdownDto>();
        var currentBalance = 0m;

        foreach (var yearAndMonth in transactions.GroupBy(x => new { x.Date.Year, x.Date.Month}))
        {
            var sumOfCredits = yearAndMonth
                .Where(x => x.Type == BankAccountTransactionType.Credit)
                .Where(x => x.Date.Year == yearAndMonth.Key.Year)
                .Where(x => x.Date.Month == yearAndMonth.Key.Month)
                .Sum(x => x.CalculationAmount);
            
            var sumOfDebits = yearAndMonth
                .Where(x => x.Type == BankAccountTransactionType.Debit)
                .Where(x => x.Date.Year == yearAndMonth.Key.Year)
                .Where(x => x.Date.Month == yearAndMonth.Key.Month)
                .Sum(x => x.CalculationAmount);

            currentBalance += (sumOfCredits + sumOfDebits);
            
            breakdowns.Add(new MonthlyBreakdownDto
            {
                Date = new DateTime(yearAndMonth.Key.Year, yearAndMonth.Key.Month, 1),
                Year = yearAndMonth.Key.Year,
                Month = yearAndMonth.Key.Month,
                OverallBalance = currentBalance,
                MonthBalance = sumOfCredits + sumOfDebits,
                RatioOfExpenses = 100 * (Math.Abs((decimal)sumOfDebits) / sumOfCredits),
                Credits = sumOfCredits,
                Debits = sumOfDebits
            });
        }

        return breakdowns;
    }
}