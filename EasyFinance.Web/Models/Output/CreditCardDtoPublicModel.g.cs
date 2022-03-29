using System;

namespace EasyFinance.Application.CreditCardCommands.Register
{
    public partial record CreditCardDtoPublicModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}