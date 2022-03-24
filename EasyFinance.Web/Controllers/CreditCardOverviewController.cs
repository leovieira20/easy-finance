using EasyFinance.Application.CreditCardCommands.Overview;
using EasyFinance.Domain.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinance.Web.Controllers;

[Route("[controller]")]
public class CreditCardOverviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public CreditCardOverviewController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{creditCardId}")]
    public async Task<IActionResult> Get(Guid creditCardId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var response = await _mediator.Send(new GetCreditCardOverviewCommand(new CreditCardId(creditCardId), startDate, endDate));

        return Ok(response);
    }
}