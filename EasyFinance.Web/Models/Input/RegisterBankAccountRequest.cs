using System.ComponentModel.DataAnnotations;

namespace EasyFinance.Web.Models.Input;

public record RegisterBankAccountRequest
{
    [Required(AllowEmptyStrings = false)]
    public string Name { get; init; } = string.Empty;
}