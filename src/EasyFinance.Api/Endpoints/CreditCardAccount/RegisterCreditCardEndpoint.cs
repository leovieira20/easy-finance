using CreditCardModule.Application;
using FastEndpoints;
using MediatR;

namespace EasyFinance.Api.Endpoints.CreditCardAccount;

public class RegisterCreditCardEndpoint : Endpoint<RegisterCreditCardRequest>
{
    private readonly IMediator _mediator;

    public RegisterCreditCardEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Post("creditCardAccount");
    }

    public override async Task HandleAsync(RegisterCreditCardRequest req, CancellationToken ct)
    {
        var response = await _mediator.Send(new RegisterCreditCard.Command(req.Name), ct);

        await SendOkAsync(response, ct);
    }
}

public class RegisterCreditCardRequest
{
    public string Name { get; set; }
}