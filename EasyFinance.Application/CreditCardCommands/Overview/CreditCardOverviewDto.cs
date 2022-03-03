namespace EasyFinance.Application.CreditCardCommands.Overview;

public class CreditCardOverviewDto
{
    public IEnumerable<CreditCardMonthlyBreakdownDto> Breakdowns { get; set; }
}