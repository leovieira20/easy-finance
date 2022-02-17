namespace EasyFinance.Web.Models.Output;

public record BankAccountPublicModel
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Name { get; init; } = string.Empty;
}