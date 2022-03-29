using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;

namespace EasyFinance.Domain.Accounts
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