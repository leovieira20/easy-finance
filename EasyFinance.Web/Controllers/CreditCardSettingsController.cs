using EasyFinance.Application.CreditCardSettingsCommands.SetLimit;
using EasyFinance.Application.CreditCardSettingsCommands.SetThreshold;
using EasyFinance.Domain.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinance.Web.Controllers;

[Route("[controller]")]
public class CreditCardSettingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CreditCardSettingsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPut("[action]/{creditCardId}")]
    public async Task<IActionResult> SetLimit(Guid creditCardId, [FromBody] decimal limitAmount)
    {
        var response = await _mediator.Send(new SetCreditCardLimitCommand(creditCardId, limitAmount));

        return Ok(response.AdaptToPublicModel());
    }
    
    [HttpPut("[action]/{creditCardId}")]
    public async Task<IActionResult> SetThreshold(Guid creditCardId, [FromBody] decimal limitAmount)
    {
        var response = await _mediator.Send(new SetCreditCardThresholdCommand(creditCardId, limitAmount));

        return Ok(response.AdaptToPublicModel());
    }
}