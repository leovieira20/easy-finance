using EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

namespace EasyFinance.Web.Models.Output;

public class BankAccountOverviewPublicModel
{
    public List<MonthlyBreakdownDto> Breakdowns { get; set; }
}