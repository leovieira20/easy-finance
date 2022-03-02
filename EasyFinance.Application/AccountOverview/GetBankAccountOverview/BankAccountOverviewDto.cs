namespace EasyFinance.Application.GetBankAccountOverview;

public class BankAccountOverviewDto
{
    public IList<MonthlyBreakdownDto> Breakdowns { get; set; }
}