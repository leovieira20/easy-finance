using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.Register;

public class RegisterCreditCardCommandHandler : IRequestHandler<RegisterCreditCardCommand, CreditCardDto>
{
    private readonly ICreditCardRepository _repository;

    public RegisterCreditCardCommandHandler(ICreditCardRepository repository)
    {
        _repository = repository;
    }
    
    public Task<CreditCardDto> Handle(RegisterCreditCardCommand request, CancellationToken cancellationToken)
    {
        var creditCard = CreditCard.Create(request.cardName);
        _repository.Create(creditCard);

        return Task.FromResult(new CreditCardDto
        {
            Id = creditCard.Id,
            Name = creditCard.Name
        });
    }
}