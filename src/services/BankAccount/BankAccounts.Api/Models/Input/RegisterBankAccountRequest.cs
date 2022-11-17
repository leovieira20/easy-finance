using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Api.Models.Input;

public record RegisterBankAccountRequest
{
    [Required(AllowEmptyStrings = false)]
    public string Name { get; init; } = string.Empty;
}