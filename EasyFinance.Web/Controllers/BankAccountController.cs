using EasyFinance.Application.RegisterBankAccount;
using EasyFinance.Web.Models.Input;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinance.Web.Controllers;

[Route("[controller]")]
public class BankAccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public BankAccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAccount([FromBody] RegisterBankAccountRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _mediator.Send(new RegisterBankAccountCommand(request.Name));

        return Ok(response.AdaptToPublicModel());
    }
}