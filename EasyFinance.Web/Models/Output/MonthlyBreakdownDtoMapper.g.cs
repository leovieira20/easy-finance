using EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

namespace EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview
{
    public static partial class MonthlyBreakdownDtoMapper
    {
        public static MonthlyBreakdownDtoPublicModel AdaptToPublicModel(this MonthlyBreakdownDto p1)
        {
            return p1 == null ? null : new MonthlyBreakdownDtoPublicModel()
            {
                Month = p1.Month,
                Balance = p1.Balance
            };
        }
        public static MonthlyBreakdownDtoPublicModel AdaptTo(this MonthlyBreakdownDto p2, MonthlyBreakdownDtoPublicModel p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MonthlyBreakdownDtoPublicModel result = p3 ?? new MonthlyBreakdownDtoPublicModel();
            
            result.Month = p2.Month;
            result.Balance = p2.Balance;
            return result;
            
        }
    }
}