using System;

namespace EasyFinance.Web.Models.Output
{
    public partial record CreditCardDtoPublicModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}