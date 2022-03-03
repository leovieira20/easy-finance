namespace EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

public class BankAccountOverviewDto
{
    public IList<MonthlyBreakdownDto> Breakdowns { get; set; }
}