using System.ComponentModel.DataAnnotations;
using EasyFinance.Web.Infrastructure.Validation;

namespace EasyFinance.Web.Models.Input;

public class RegisterDepositToBankAccountRequest
{
    [Required]
    [ValidGuid]
    public Guid BankAccountId { get; set; }
    
    [Range(0.1, 999999.99)]
    public decimal Amount { get; set; }

    public DateTime Date { get; set; }
}