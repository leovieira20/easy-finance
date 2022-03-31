using System;

namespace EasyFinance.Web.Models.Output
{
    public partial record BankAccountDtoPublicModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}