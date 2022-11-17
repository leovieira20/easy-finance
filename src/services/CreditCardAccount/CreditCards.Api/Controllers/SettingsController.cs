using CreditCards.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCards.Api.Controllers;

[Route("[controller]")]
public class SettingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SettingsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPut("[action]/{creditCardId}")]
    public async Task<IActionResult> SetLimit(Guid creditCardId, [FromBody] decimal limitAmount)
    {
        var response = await _mediator.Send(new SetCreditCardLimit.Command(creditCardId, limitAmount));

        return Ok(response);
    }
    
    [HttpPut("[action]/{creditCardId}")]
    public async Task<IActionResult> SetThreshold(Guid creditCardId, [FromBody] decimal limitAmount)
    {
        var response = await _mediator.Send(new SetCreditCardThresholdLimit.Command(creditCardId, limitAmount));

        return Ok(response);
    }
    
    [HttpPut("[action]/{creditCardId}")]
    public async Task<IActionResult> SetDefaultPaymentAmount(Guid creditCardId, [FromBody] decimal limitAmount)
    {
        var response = await _mediator.Send(new SetCreditCardDefaultPaymentAmount.Command(creditCardId, limitAmount));

        return Ok(response);
    }
}