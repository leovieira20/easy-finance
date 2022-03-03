namespace EasyFinance.Application.CreditCardCommands.Overview;

public record CreditCardOverviewDto
{
    public IEnumerable<CreditCardMonthlyBreakdownDto> Breakdowns { get; set; }
}