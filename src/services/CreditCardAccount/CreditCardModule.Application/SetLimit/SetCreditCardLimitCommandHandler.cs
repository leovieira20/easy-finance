using CreditCardModule.Domain;
using MediatR;

namespace CreditCardModule.Application.SetLimit;

class SetCreditCardLimitCommandHandler : IRequestHandler<SetCreditCardLimitCommand, CreditCardSettings>
{
    private readonly ICreditCardRepository _repository;

    public SetCreditCardLimitCommandHandler(ICreditCardRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<CreditCardSettings> Handle(SetCreditCardLimitCommand request, CancellationToken cancellationToken)
    {
        var creditCard = await _repository.GetSettingsAsync(new CreditCardId(request.creditCardId));

        creditCard?.SetLimit(request.amount);

        _repository.Update(creditCard);

        return creditCard.Settings;
    }
}