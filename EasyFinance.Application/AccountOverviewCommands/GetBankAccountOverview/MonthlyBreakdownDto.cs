namespace EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

public record MonthlyBreakdownDto
{
    public int Month { get; set; }
    public decimal Balance { get; set; }
}