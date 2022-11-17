using CreditCards.Application;
using FastEndpoints;
using MediatR;

namespace EasyFinance.Api.Endpoints.CreditCardAccount;

public class GetCreditCardOverviewEndpoint : Endpoint<CreditCardOverviewRequest>
{
    private readonly IMediator _mediator;

    public GetCreditCardOverviewEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Get("creditCardAccount{accountId}/overview");
    }

    public override async Task HandleAsync(CreditCardOverviewRequest req, CancellationToken ct)
    {
        var response = await _mediator.Send(new GetCreditCardOverview.Query(new(req.Id), req.StartDate, req.EndDate), ct);

        await SendOkAsync(response, ct);
    }
}

public class CreditCardOverviewRequest
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}