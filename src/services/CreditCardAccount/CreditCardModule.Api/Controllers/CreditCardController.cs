using CreditCardModule.Api.Models.Input;
using CreditCardModule.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardModule.Api.Controllers;

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
        var response = await _mediator.Send(new RegisterCreditCard.Command(request.Name));
        
        return Ok(response);
    }
}