using System.ComponentModel.DataAnnotations;

namespace EasyFinance.Web.Models.Input;

public class ShowBankAccountTransactionsRequest
{
    [Required]
    [ValidGuid]
    public Guid BankAccountId { get; set; }
}