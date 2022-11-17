using CreditCards.Application;
using FastEndpoints;
using MediatR;

namespace EasyFinance.Api.Endpoints.CreditCardAccount;

public class SetCreditCardThresholdEndpoint : Endpoint<SetCreditCardThresholdRequest>
{
    private readonly IMediator _mediator;

    public SetCreditCardThresholdEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Put("creditCardAccount/{accountId}/settings/threshold");
    }

    public override async Task HandleAsync(SetCreditCardThresholdRequest req, CancellationToken ct)
    {
        var response = await _mediator.Send(new SetCreditCardThresholdLimit.Command(req.CreditCardId, req.LimitAmount), ct);

        await SendOkAsync(response, ct);
    }
}

public class SetCreditCardThresholdRequest
{
    public Guid CreditCardId { get; set; }
    public decimal LimitAmount { get; set; }
}