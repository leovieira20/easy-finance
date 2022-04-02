using CreditCardModule.Domain;

namespace EasyFinance.Web.Models.Output
{
    public partial record CreditCardSettingsPublicModel
    {
        public CreditCardSettingsId Id { get; set; }
        public decimal Limit { get; set; }
        public decimal Threshold { get; set; }
        public decimal DefaultPaymentAmount { get; set; }
        public CreditCardId CreditCardId { get; set; }
    }
}