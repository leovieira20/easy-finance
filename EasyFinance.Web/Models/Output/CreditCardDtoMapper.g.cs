using CreditCardModule.Application.Register;
using EasyFinance.Web.Models.Output;

namespace EasyFinance.Web.Models.Output
{
    public static partial class CreditCardDtoMapper
    {
        public static CreditCardDtoPublicModel AdaptToPublicModel(this CreditCardDto p1)
        {
            return p1 == null ? null : new CreditCardDtoPublicModel()
            {
                Id = p1.Id,
                Name = p1.Name
            };
        }
        public static CreditCardDtoPublicModel AdaptTo(this CreditCardDto p2, CreditCardDtoPublicModel p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CreditCardDtoPublicModel result = p3 ?? new CreditCardDtoPublicModel();
            
            result.Id = p2.Id;
            result.Name = p2.Name;
            return result;
            
        }
    }
}