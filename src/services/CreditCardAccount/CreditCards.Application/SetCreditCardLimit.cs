using CreditCards.Domain;
using MediatR;

namespace CreditCards.Application;

public static class SetCreditCardLimit
{
    public record Command(Guid creditCardId, decimal amount) : IRequest<CreditCardSettings>;
    class Handler : IRequestHandler<Command, CreditCardSettings>
    {
        private readonly ICreditCardRepository _repository;

        public Handler(ICreditCardRepository repository)
        {
            _repository = repository;
        }
    
        public async Task<CreditCardSettings> Handle(Command request, CancellationToken cancellationToken)
        {
            var creditCard = await _repository.GetSettingsAsync(new(request.creditCardId));

            creditCard?.SetLimit(request.amount);

            _repository.Update(creditCard);

            return creditCard.Settings;
        }
    }    
}
