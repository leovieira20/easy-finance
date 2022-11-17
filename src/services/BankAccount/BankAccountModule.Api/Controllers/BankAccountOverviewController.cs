using BankAccountModule.Api.Models.Input;
using BankAccountModule.Application;
using BankAccountModule.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountModule.Api.Controllers;

[Route("[controller]")]
public class BankAccountOverviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public BankAccountOverviewController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(GetBankAccountOverviewRequest request)
    {
        var monthlyBreakdowns = await _mediator
            .Send(new GetBankAccountOverview.Query(new BankAccountId(request.Id),
                request.StartDate,
                request.EndDate));
        
        return Ok(monthlyBreakdowns);
    }
}