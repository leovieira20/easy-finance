using System.ComponentModel.DataAnnotations;
using BankAccounts.Application;
using FastEndpoints;
using MediatR;
using Web.Common;

namespace EasyFinance.Api.Endpoints.BankAccount;

public class RegisterBankAccountDebitEndpoint : Endpoint<RegisterBankAccountDebitRequest>
{
    private readonly IMediator _mediator;

    public RegisterBankAccountDebitEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Post("bankAccount/{accountId}/debit");
    }

    public override async Task HandleAsync(RegisterBankAccountDebitRequest req, CancellationToken ct)
    {
        var response = await _mediator
            .Send(new RegisterPaymentToBankAccount.Command(req.BankAccountId, req.Amount, req.Date), ct);

        await SendOkAsync(response, ct);
    }
}

public class RegisterBankAccountDebitRequest
{
    [Required]
    [ValidGuid]
    public Guid BankAccountId { get; set; }
    
    [Range(-999999.99, -0.1)]
    public decimal Amount { get; set; }

    public DateTime Date { get; set; }
}