using System;

namespace EasyFinance.Application.BankAccountCommands.RegisterBankAccount
{
    public partial record BankAccountDtoPublicModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}