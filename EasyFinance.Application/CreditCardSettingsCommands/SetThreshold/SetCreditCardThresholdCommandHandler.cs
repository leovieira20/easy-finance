using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.CreditCardSettingsCommands.SetThreshold;

class SetCreditCardThresholdLimitCommandHandler : IRequestHandler<SetCreditCardThresholdCommand, CreditCardSettings>
{
    private readonly ICreditCardRepository _repository;

    public SetCreditCardThresholdLimitCommandHandler(ICreditCardRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<CreditCardSettings> Handle(SetCreditCardThresholdCommand request, CancellationToken cancellationToken)
    {
        var creditCard = await _repository.GetSettingsAsync(new CreditCardId(request.creditCardId));

        creditCard?.SetThreshold(request.amount);

        _repository.Update(creditCard);

        return creditCard.Settings;
    }
}