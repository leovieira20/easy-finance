using EasyFinance.Application.Account.RegisterDepositToBankAccount;

namespace EasyFinance.Application.Account.RegisterDepositToBankAccount
{
    public static partial class BankAccountSummaryDtoMapper
    {
        public static BankAccountSummaryDtoPublicModel AdaptToPublicModel(this BankAccountSummaryDto p1)
        {
            return p1 == null ? null : new BankAccountSummaryDtoPublicModel() {Balance = p1.Balance};
        }
        public static BankAccountSummaryDtoPublicModel AdaptTo(this BankAccountSummaryDto p2, BankAccountSummaryDtoPublicModel p3)
        {
            if (p2 == null)
            {
                return null;
            }
            BankAccountSummaryDtoPublicModel result = p3 ?? new BankAccountSummaryDtoPublicModel();
            
            result.Balance = p2.Balance;
            return result;
            
        }
    }
}