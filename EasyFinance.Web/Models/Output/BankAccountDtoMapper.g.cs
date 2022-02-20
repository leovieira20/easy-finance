using EasyFinance.Application.Account.RegisterBankAccount;

namespace EasyFinance.Application.Account.RegisterBankAccount
{
    public static partial class BankAccountDtoMapper
    {
        public static BankAccountDtoPublicModel AdaptToPublicModel(this BankAccountDto p1)
        {
            return p1 == null ? null : new BankAccountDtoPublicModel()
            {
                Id = p1.Id,
                Name = p1.Name,
                Status = p1.Status
            };
        }
        public static BankAccountDtoPublicModel AdaptTo(this BankAccountDto p2, BankAccountDtoPublicModel p3)
        {
            if (p2 == null)
            {
                return null;
            }
            BankAccountDtoPublicModel result = p3 ?? new BankAccountDtoPublicModel();
            
            result.Id = p2.Id;
            result.Name = p2.Name;
            result.Status = p2.Status;
            return result;
            
        }
    }
}