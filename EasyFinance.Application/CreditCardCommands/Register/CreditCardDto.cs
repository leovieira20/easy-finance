namespace EasyFinance.Application.CreditCardCommands.Register;

public record CreditCardDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}