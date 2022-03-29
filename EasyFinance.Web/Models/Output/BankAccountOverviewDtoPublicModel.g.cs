using System.Collections.Generic;
using EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

namespace EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview
{
    public partial record BankAccountOverviewDtoPublicModel
    {
        public IList<MonthlyBreakdownDtoPublicModel> Breakdowns { get; set; }
    }
}