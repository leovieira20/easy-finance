using System.ComponentModel.DataAnnotations;
using EasyFinance.Web.Infrastructure.Validation;

namespace EasyFinance.Web.Models.Input;

public class ShowBankAccountTransactionsRequest
{
    [Required]
    [ValidGuid]
    public Guid BankAccountId { get; set; }
}