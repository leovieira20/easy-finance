namespace EasyFinance.Application.AccountOverview.GetBankAccountOverview;

public class BankAccountOverviewDto
{
    public IList<MonthlyBreakdownDto> Breakdowns { get; set; }
}