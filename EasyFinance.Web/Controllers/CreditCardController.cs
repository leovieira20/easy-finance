using EasyFinance.Application.CreditCardCommands.Register;
using EasyFinance.Web.Models.Input;
using EasyFinance.Web.Models.Output;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinance.Web.Controllers;

[Route("[controller]")]
public class CreditCardController : ControllerBase
{
    private readonly IMediator _mediator;

    public CreditCardController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] RegisterCreditCardRequest request)
    {
        var response = await _mediator.Send(new RegisterCreditCardCommand(request.Name));
        
        return Ok(response.AdaptToPublicModel());
    }
}