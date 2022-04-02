namespace BankAccountModule.Application.RegisterBankAccount;

public record BankAccountDto
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Name { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
}