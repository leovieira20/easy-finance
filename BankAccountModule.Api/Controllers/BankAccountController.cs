using BankAccountModule.Api.Models.Input;
using BankAccountModule.Application.RegisterBankAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountModule.Api.Controllers;

[Route("[controller]")]
public class BankAccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public BankAccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] RegisterBankAccountRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _mediator.Send(new RegisterBankAccountCommand(request.Name));

        return Ok(response);
    }
}