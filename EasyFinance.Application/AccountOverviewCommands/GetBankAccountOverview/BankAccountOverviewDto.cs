namespace EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

public record BankAccountOverviewDto
{
    public IList<MonthlyBreakdownDto> Breakdowns { get; set; }
}