using EasyFinance.Application.Account.ShowBankAccountTransactions;

namespace EasyFinance.Application.Account.ShowBankAccountTransactions
{
    public static partial class BankAccountTransactionDtoMapper
    {
        public static BankAccountTransactionDtoPublicModel AdaptToPublicModel(this BankAccountTransactionDto p1)
        {
            return p1 == null ? null : new BankAccountTransactionDtoPublicModel() {Amount = p1.Amount};
        }
        public static BankAccountTransactionDtoPublicModel AdaptTo(this BankAccountTransactionDto p2, BankAccountTransactionDtoPublicModel p3)
        {
            if (p2 == null)
            {
                return null;
            }
            BankAccountTransactionDtoPublicModel result = p3 ?? new BankAccountTransactionDtoPublicModel();
            
            result.Amount = p2.Amount;
            return result;
            
        }
    }
}