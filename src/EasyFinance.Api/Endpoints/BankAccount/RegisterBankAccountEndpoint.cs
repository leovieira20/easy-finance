using System.ComponentModel.DataAnnotations;
using BankAccountModule.Application;
using FastEndpoints;
using MediatR;

namespace EasyFinance.Api.Endpoints.BankAccount;

public class RegisterBankAccountEndpoint : Endpoint<RegisterBankAccountRequest>
{
    private readonly IMediator _mediator;

    public RegisterBankAccountEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Post("bankAccount");
    }

    public override async Task HandleAsync(RegisterBankAccountRequest req, CancellationToken ct)
    {
        var response = await _mediator.Send(new RegisterBankAccount.Command(req.Name), ct);

        await SendOkAsync(response, ct);
    }
}

public class RegisterBankAccountRequest
{
    [Required(AllowEmptyStrings = false)]
    public string Name { get; init; } = string.Empty;
}