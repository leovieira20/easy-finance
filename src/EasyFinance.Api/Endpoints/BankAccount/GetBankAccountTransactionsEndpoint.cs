using System.ComponentModel.DataAnnotations;
using BankAccountModule.Application;
using FastEndpoints;
using MediatR;
using Web.Common;

namespace EasyFinance.Api.Endpoints.BankAccount;

public class GetBankAccountTransactionsEndpoint : Endpoint<GetBankAccountTransactionsRequest>
{
    private readonly IMediator _mediator;

    public GetBankAccountTransactionsEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Get("bankAccount/{accountId}/transactions");
    }

    public override async Task HandleAsync(GetBankAccountTransactionsRequest req, CancellationToken ct)
    {
        var transactions = await _mediator.Send(new GetBankAccountTransactions.Query(req.BankAccountId), ct);

        await SendOkAsync(transactions, ct);
    }
}

public class GetBankAccountTransactionsRequest
{
    [Required]
    [ValidGuid]
    public Guid BankAccountId { get; set; }
}