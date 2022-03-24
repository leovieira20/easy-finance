namespace EasyFinance.Application.CreditCardCommands.Overview;

public record CreditCardMonthlyBreakdownDto
{
    public DateTime Date { get; set; }
    public decimal Balance { get; set; }
    public decimal ForecastBalance { get; set; }
}