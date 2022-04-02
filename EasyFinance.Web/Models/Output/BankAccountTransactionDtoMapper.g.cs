using BankAccountModule.Application.GetBankAccountTransactions;
using EasyFinance.Web.Models.Output;

namespace EasyFinance.Web.Models.Output
{
    public static partial class BankAccountTransactionDtoMapper
    {
        public static BankAccountTransactionDtoPublicModel AdaptToPublicModel(this BankAccountTransactionDto p1)
        {
            return p1 == null ? null : new BankAccountTransactionDtoPublicModel()
            {
                Date = p1.Date,
                Amount = p1.Amount,
                Description = p1.Description
            };
        }
        public static BankAccountTransactionDtoPublicModel AdaptTo(this BankAccountTransactionDto p2, BankAccountTransactionDtoPublicModel p3)
        {
            if (p2 == null)
            {
                return null;
            }
            BankAccountTransactionDtoPublicModel result = p3 ?? new BankAccountTransactionDtoPublicModel();
            
            result.Date = p2.Date;
            result.Amount = p2.Amount;
            result.Description = p2.Description;
            return result;
            
        }
    }
}