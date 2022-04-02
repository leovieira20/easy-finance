using System.ComponentModel.DataAnnotations;
using EasyFinance.Web.Infrastructure.Validation;

namespace EasyFinance.Web.Models.Input;

public class GetBankAccountTransactionsRequest
{
    [Required]
    [ValidGuid]
    public Guid BankAccountId { get; set; }
}