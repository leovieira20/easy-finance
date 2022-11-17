using CreditCards.Application;
using CreditCards.Api.Models.Input;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCards.Api.Controllers;

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
        var response = await _mediator.Send(new GetCreditCardOverview.Query(new(request.Id), request.StartDate, request.EndDate));

        return Ok(response);
    }
}