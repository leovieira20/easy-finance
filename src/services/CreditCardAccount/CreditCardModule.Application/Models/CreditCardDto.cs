namespace CreditCardModule.Application.Models;

public record CreditCardDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}