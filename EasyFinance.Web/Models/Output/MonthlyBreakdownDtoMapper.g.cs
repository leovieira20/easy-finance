using EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;
using EasyFinance.Web.Models.Output;

namespace EasyFinance.Web.Models.Output
{
    public static partial class MonthlyBreakdownDtoMapper
    {
        public static MonthlyBreakdownDtoPublicModel AdaptToPublicModel(this MonthlyBreakdownDto p1)
        {
            return p1 == null ? null : new MonthlyBreakdownDtoPublicModel()
            {
                Date = p1.Date,
                Year = p1.Year,
                Month = p1.Month,
                Credits = p1.Credits,
                Debits = p1.Debits
            };
        }
        public static MonthlyBreakdownDtoPublicModel AdaptTo(this MonthlyBreakdownDto p2, MonthlyBreakdownDtoPublicModel p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MonthlyBreakdownDtoPublicModel result = p3 ?? new MonthlyBreakdownDtoPublicModel();
            
            result.Date = p2.Date;
            result.Year = p2.Year;
            result.Month = p2.Month;
            result.Credits = p2.Credits;
            result.Debits = p2.Debits;
            return result;
            
        }
    }
}