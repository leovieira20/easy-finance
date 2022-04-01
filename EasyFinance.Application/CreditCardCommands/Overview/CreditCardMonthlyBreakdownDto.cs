namespace EasyFinance.Application.CreditCardCommands.Overview;

public record CreditCardMonthlyBreakdownDto
{
    public DateTime Date { get; set; }
    public decimal OverallBalance { get; set; }
    public decimal MonthBalance { get; set; }
    public decimal ForecastBalance { get; set; }
    public decimal Expenses { get; set; }
    public decimal Payments { get; set; }
}