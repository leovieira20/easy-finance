namespace EasyFinance.Application.Overview;

public class CreditCardOverviewDto
{
    public IEnumerable<CreditCardMonthlyBreakdownDto> Breakdowns { get; set; }
}