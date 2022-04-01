namespace EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

public record MonthlyBreakdownDto
{
    public DateTime Date { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal OverallBalance { get; set; }
    public decimal MonthBalance { get; set; }
    public decimal Credits { get; set; }
    public decimal Debits { get; set; }
    public decimal RatioOfExpenses { get; set; }
}