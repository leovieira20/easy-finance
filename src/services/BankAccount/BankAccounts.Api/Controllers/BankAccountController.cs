using BankAccounts.Application;
using BankAccounts.Api.Models.Input;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankAccounts.Api.Controllers;

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

        var response = await _mediator.Send(new RegisterBankAccount.Command(request.Name));

        return Ok(response);
    }
}