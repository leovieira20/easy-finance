using System.ComponentModel.DataAnnotations;
using Web.Common;

namespace BankAccounts.Api.Models.Input;

public class GetBankAccountTransactionsRequest
{
    [Required]
    [ValidGuid]
    public Guid BankAccountId { get; set; }
}