using System.Collections.Generic;
using EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

namespace EasyFinance.Web.Models.Output
{
    public static partial class BankAccountOverviewDtoMapper
    {
        public static BankAccountOverviewDtoPublicModel AdaptToPublicModel(this IList<MonthlyBreakdownDto> p1)
        {
            return p1 == null ? null : new BankAccountOverviewDtoPublicModel() {Breakdowns = funcMain1(p1)};
        }
        public static BankAccountOverviewDtoPublicModel AdaptTo(this IList<MonthlyBreakdownDto> p3, BankAccountOverviewDtoPublicModel p4)
        {
            if (p3 == null)
            {
                return null;
            }
            BankAccountOverviewDtoPublicModel result = p4 ?? new BankAccountOverviewDtoPublicModel();
            
            result.Breakdowns = funcMain2(p3, result.Breakdowns);
            return result;
            
        }
        
        private static IList<MonthlyBreakdownDtoPublicModel> funcMain1(IList<MonthlyBreakdownDto> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            IList<MonthlyBreakdownDtoPublicModel> result = new List<MonthlyBreakdownDtoPublicModel>(p2.Count);
            
            ICollection<MonthlyBreakdownDtoPublicModel> list = result;
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                MonthlyBreakdownDto item = p2[i];
                list.Add(item == null ? null : new MonthlyBreakdownDtoPublicModel()
                {
                    Month = item.Month,
                    Balance = item.Balance
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<MonthlyBreakdownDtoPublicModel> funcMain2(IList<MonthlyBreakdownDto> p5, IList<MonthlyBreakdownDtoPublicModel> p6)
        {
            if (p5 == null)
            {
                return null;
            }
            IList<MonthlyBreakdownDtoPublicModel> result = new List<MonthlyBreakdownDtoPublicModel>(p5.Count);
            
            ICollection<MonthlyBreakdownDtoPublicModel> list = result;
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                MonthlyBreakdownDto item = p5[i];
                list.Add(item == null ? null : new MonthlyBreakdownDtoPublicModel()
                {
                    Month = item.Month,
                    Balance = item.Balance
                });
                i++;
            }
            return result;
            
        }
    }
}