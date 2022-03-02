using System.ComponentModel.DataAnnotations;
using EasyFinance.Web.Infrastructure.Validation;

namespace EasyFinance.Web.Models.Input;

public class RegisterPaymentToBankAccountRequest
{
    [Required]
    [ValidGuid]
    public Guid BankAccountId { get; set; }
    
    [Range(-999999.99, -0.1)]
    public decimal Amount { get; set; }

    public DateTime Date { get; set; }
}