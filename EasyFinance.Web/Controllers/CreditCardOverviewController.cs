using EasyFinance.Application.CreditCardCommands.Overview;
using EasyFinance.Domain.Accounts;
using EasyFinance.Web.Models.Input;
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
    
    [HttpGet]
    public async Task<IActionResult> Get(CreditCardOverviewRequest request)
    {
        var response = await _mediator.Send(new GetCreditCardOverviewCommand(new CreditCardId(request.Id), request.StartDate, request.EndDate));

        return Ok(response);
    }
}