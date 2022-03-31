using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

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
            var sumOfTransactions = transactions
                .Where(x => x.Date.Year == yearAndMonth.Key.Year)
                .Where(x => x.Date.Month == yearAndMonth.Key.Month)
                .Sum(x => x.Amount);

            currentBalance += sumOfTransactions;
            
            breakdowns.Add(new MonthlyBreakdownDto
            {
                Balance = currentBalance,
                Month = yearAndMonth.Key.Month
            });
        }

        return breakdowns;
    }
}