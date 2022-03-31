using System.Collections.Generic;
using EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

namespace EasyFinance.Web.Models.Output
{
    public partial record BankAccountOverviewDtoPublicModel
    {
        public IList<MonthlyBreakdownDtoPublicModel> Breakdowns { get; set; }
    }
}