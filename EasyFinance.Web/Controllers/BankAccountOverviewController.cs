using EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;
using EasyFinance.Domain.Accounts;
using EasyFinance.Web.Models.Input;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinance.Web.Controllers;

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
        var bankAccountOverview = await _mediator
            .Send(new GetBankAccountOverviewCommand(new BankAccountId(request.Id),
                request.StartDate,
                request.EndDate));
        
        return Ok(bankAccountOverview.AdaptToPublicModel());
    }
}