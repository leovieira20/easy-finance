using CreditCardModule.Api.Models.Input;
using CreditCardModule.Application.Overview;
using CreditCardModule.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardModule.Api.Controllers;

[Route("[controller]")]
public class OverviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public OverviewController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(CreditCardOverviewRequest request)
    {
        var response = await _mediator.Send(new GetCreditCardOverviewCommand(new CreditCardId(request.Id), request.StartDate, request.EndDate));

        return Ok(response);
    }
}