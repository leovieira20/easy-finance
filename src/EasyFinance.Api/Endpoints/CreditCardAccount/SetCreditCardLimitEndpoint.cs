using CreditCards.Application;
using FastEndpoints;
using MediatR;

namespace EasyFinance.Api.Endpoints.CreditCardAccount;

public class SetCreditCardLimitEndpoint : Endpoint<SetCreditCardLimitRequest>
{
    private readonly IMediator _mediator;

    public SetCreditCardLimitEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Put("creditCardAccount/{accountId}/settings/limit");
    }

    public override async Task HandleAsync(SetCreditCardLimitRequest req, CancellationToken ct)
    {
        var response = await _mediator.Send(new SetCreditCardLimit.Command(req.CreditCardId, req.LimitAmount), ct);

        await SendOkAsync(response, ct);
    }
}

public class SetCreditCardLimitRequest
{
    public Guid CreditCardId { get; set; }
    public decimal LimitAmount { get; set; }
}