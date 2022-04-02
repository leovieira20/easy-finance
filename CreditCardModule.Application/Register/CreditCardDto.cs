namespace CreditCardModule.Application.Register;

public record CreditCardDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}