using BankAccounts.Application;
using FastEndpoints;
using MediatR;

namespace EasyFinance.Api.Endpoints.BankAccount;

public class GetBankAccountOverviewEndpoint : Endpoint<GetBankAccountOverviewRequest>
{
    private readonly IMediator _mediator;

    public GetBankAccountOverviewEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Get("bankAccount/overview");
    }

    public override async Task HandleAsync(GetBankAccountOverviewRequest req, CancellationToken ct)
    {
        var monthlyBreakdowns = await _mediator
            .Send(new GetBankAccountOverview.Query(new(req.Id),
                req.StartDate,
                req.EndDate), ct);
        
        await SendOkAsync(monthlyBreakdowns, ct);
    }
}

public class GetBankAccountOverviewRequest
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}