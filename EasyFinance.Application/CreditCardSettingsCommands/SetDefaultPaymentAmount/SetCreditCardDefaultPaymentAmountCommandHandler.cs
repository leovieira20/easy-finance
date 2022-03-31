using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.CreditCardSettingsCommands.SetDefaultPaymentAmount;

class SetCreditCardDefaultPaymentAmountCommandHandler : IRequestHandler<SetCreditCardDefaultPaymentAmountCommand, CreditCardSettings>
{
    private readonly ICreditCardRepository _repository;

    public SetCreditCardDefaultPaymentAmountCommandHandler(ICreditCardRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<CreditCardSettings> Handle(SetCreditCardDefaultPaymentAmountCommand request, CancellationToken cancellationToken)
    {
        var creditCard = await _repository.GetSettingsAsync(new CreditCardId(request.creditCardId));

        creditCard?.SetDefaultPaymentAmount(request.amount);

        _repository.Update(creditCard);

        return creditCard.Settings;
    }
}