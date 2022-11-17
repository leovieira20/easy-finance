using CreditCards.Application;
using FastEndpoints;
using MediatR;

namespace EasyFinance.Api.Endpoints.CreditCardAccount;

public class GetTransactionsEndpoint : Endpoint<GetTransactionsRequest>
{
    private readonly IMediator _mediator;

    public GetTransactionsEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Get("creditCardAccount/{accountId}/transactions");
    }

    public override async Task HandleAsync(GetTransactionsRequest req, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetCreditCardTransactions.Query(req.CreditCardId, req.StartDate, req.EndDate), ct);

        await SendOkAsync(result, ct);
    }
}

public class GetTransactionsRequest
{
    public Guid CreditCardId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}