namespace EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

public record MonthlyBreakdownDto
{
    public DateTime Date { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal Balance { get; set; }
}