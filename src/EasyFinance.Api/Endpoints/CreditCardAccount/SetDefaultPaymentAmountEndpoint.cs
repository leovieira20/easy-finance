using CreditCardModule.Application;
using FastEndpoints;
using MediatR;

namespace EasyFinance.Api.Endpoints.CreditCardAccount;

public class SetDefaultPaymentAmountEndpoint : Endpoint<SetDefaultPaymentAmountRequest>
{
    private readonly IMediator _mediator;

    public SetDefaultPaymentAmountEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Put("creditCardAccount/{accountId}/settings/defaultPaymentAmount");
    }

    public override async Task HandleAsync(SetDefaultPaymentAmountRequest req, CancellationToken ct)
    {
        var response = await _mediator.Send(new SetCreditCardDefaultPaymentAmount.Command(req.CreditCardId, req.LimitAmount), ct);

        await SendOkAsync(response, ct);
    }
}

public class SetDefaultPaymentAmountRequest
{
    public Guid CreditCardId { get; set; }
    public decimal LimitAmount { get; set; }
}