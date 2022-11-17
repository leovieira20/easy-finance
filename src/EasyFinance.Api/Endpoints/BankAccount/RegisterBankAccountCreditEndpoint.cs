using System.ComponentModel.DataAnnotations;
using BankAccountModule.Application;
using FastEndpoints;
using MediatR;
using Web.Common;

namespace EasyFinance.Api.Endpoints.BankAccount;

public class RegisterBankAccountCreditEndpoint : Endpoint<RegisterBankAccountCreditRequest>
{
    private readonly IMediator _mediator;

    public RegisterBankAccountCreditEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Post("bankAccount/{accountId}/credit");
    }

    public override async Task HandleAsync(RegisterBankAccountCreditRequest req, CancellationToken ct)
    {
        var response = await _mediator
            .Send(new RegisterDepositToBankAccount.Command(req.BankAccountId, req.Amount, req.Date), ct);

        await SendOkAsync(response, ct);
    }
}

public class RegisterBankAccountCreditRequest
{
    [Required]
    [ValidGuid]
    public Guid BankAccountId { get; set; }
    
    [Range(0.1, 999999.99)]
    public decimal Amount { get; set; }

    public DateTime Date { get; set; }
}