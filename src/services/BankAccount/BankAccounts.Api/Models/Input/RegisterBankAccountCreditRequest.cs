using System.ComponentModel.DataAnnotations;
using Web.Common;

namespace BankAccounts.Api.Models.Input;

public class RegisterBankAccountCreditRequest
{
    [Required]
    [ValidGuid]
    public Guid BankAccountId { get; set; }
    
    [Range(0.1, 999999.99)]
    public decimal Amount { get; set; }

    public DateTime Date { get; set; }
}