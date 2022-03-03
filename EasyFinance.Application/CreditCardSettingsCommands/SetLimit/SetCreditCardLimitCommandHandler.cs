using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.CreditCardSettingsCommands.SetLimit;

class SetCreditCardLimitCommandHandler : IRequestHandler<SetCreditCardLimitCommand, CreditCardSettings>
{
    private readonly ICreditCardRepository _repository;

    public SetCreditCardLimitCommandHandler(ICreditCardRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<CreditCardSettings> Handle(SetCreditCardLimitCommand request, CancellationToken cancellationToken)
    {
        var creditCard = await _repository.GetSettingsAsync(request.creditCardId);

        creditCard?.SetLimit(request.amount);

        _repository.Update(creditCard);

        return creditCard.Settings;
    }
}