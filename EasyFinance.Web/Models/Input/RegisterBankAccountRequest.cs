namespace EasyFinance.Web.Models.Input;

public record RegisterBankAccountRequest
{
    public string Name { get; init; } = string.Empty;
}