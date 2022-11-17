using CreditCardModule.Application.Models;
using CreditCardModule.Domain;
using MediatR;

namespace CreditCardModule.Application;

public static class RegisterCreditCard
{
    public record Command(string cardName) : IRequest<CreditCardDto>;
    class Handler : IRequestHandler<Command, CreditCardDto>
    {
        private readonly ICreditCardRepository _repository;

        public Handler(ICreditCardRepository repository)
        {
            _repository = repository;
        }
    
        public Task<CreditCardDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var creditCard = CreditCard.Create(request.cardName);
            _repository.Create(creditCard);

            return Task.FromResult(new CreditCardDto
            {
                Id = creditCard.Id.Value,
                Name = creditCard.Name
            });
        }
    }    
}
