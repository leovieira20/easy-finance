using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

class GetBankAccountOverviewCommandHandler : IRequestHandler<GetBankAccountOverviewCommand, BankAccountOverviewDto>
{
    private readonly IBankAccountTransactionRepository _bankAccountRepository;

    public GetBankAccountOverviewCommandHandler(IBankAccountTransactionRepository bankAccountRepository)
    {
        _bankAccountRepository = bankAccountRepository;
    }
    
    public async Task<BankAccountOverviewDto> Handle(GetBankAccountOverviewCommand request, CancellationToken cancellationToken)
    {
        var transactions = await _bankAccountRepository
            .GetForBankAccountAsync(request.bankAccountId, request.startDate, request.endDate);

        var breakdowns = new List<MonthlyBreakdownDto>();
        var currentBalance = 0m;

        foreach (var months in transactions.GroupBy(x => x.Date.Month))
        {
            var sumOfTransactions = transactions
                .Where(x => x.Date.Month == months.Key)
                .Sum(x => x.Amount);

            currentBalance += sumOfTransactions;
            
            breakdowns.Add(new MonthlyBreakdownDto
            {
                Balance = currentBalance,
                Month = months.Key
            });
        }

        var overview = new BankAccountOverviewDto
        {
            Breakdowns = breakdowns
        };

        return overview;
    }
}