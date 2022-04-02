using System;

namespace EasyFinance.Web.Models.Output
{
    public partial record BankAccountTransactionDtoPublicModel
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}