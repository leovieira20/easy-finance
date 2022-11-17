using System.ComponentModel.DataAnnotations;
using Web.Common;

namespace BankAccounts.Api.Models.Input;

public class RegisterBankAccountDebitRequest
{
    [Required]
    [ValidGuid]
    public Guid BankAccountId { get; set; }
    
    [Range(-999999.99, -0.1)]
    public decimal Amount { get; set; }

    public DateTime Date { get; set; }
}