using CreditCardModule.Domain;
using EasyFinance.Web.Models.Output;

namespace EasyFinance.Web.Models.Output
{
    public static partial class CreditCardSettingsMapper
    {
        public static CreditCardSettingsPublicModel AdaptToPublicModel(this CreditCardSettings p1)
        {
            return p1 == null ? null : new CreditCardSettingsPublicModel()
            {
                Id = new CreditCardSettingsId(p1.Id.Value),
                Limit = p1.Limit,
                Threshold = p1.Threshold,
                DefaultPaymentAmount = p1.DefaultPaymentAmount,
                CreditCardId = new CreditCardId(p1.CreditCardId.Value)
            };
        }
        public static CreditCardSettingsPublicModel AdaptTo(this CreditCardSettings p2, CreditCardSettingsPublicModel p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CreditCardSettingsPublicModel result = p3 ?? new CreditCardSettingsPublicModel();
            
            result.Id = new CreditCardSettingsId(p2.Id.Value);
            result.Limit = p2.Limit;
            result.Threshold = p2.Threshold;
            result.DefaultPaymentAmount = p2.DefaultPaymentAmount;
            result.CreditCardId = new CreditCardId(p2.CreditCardId.Value);
            return result;
            
        }
    }
}