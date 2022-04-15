using BankAccountModule.Api.Models.Input;
using BankAccountModule.Application.GetBankAccountTransactions;
using BankAccountModule.Application.RegisterDepositToBankAccount;
using BankAccountModule.Application.RegisterPaymentToBankAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountModule.Api.Controllers;

[Route("[controller]")]
public class BankAccountTransactionController : ControllerBase
{
    private readonly IMediator _mediator;

    public BankAccountTransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetBankAccountTransactionsRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var transactions = await _mediator.Send(new GetBankAccountTransactionsCommand(request.BankAccountId));

        return Ok(transactions);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterCredit([FromBody] RegisterBankAccountCreditRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _mediator
            .Send(new RegisterDepositToBankAccountCommand(request.BankAccountId, request.Amount, request.Date));

        return Ok(response);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterDebit([FromBody] RegisterBankAccountDebitRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _mediator
            .Send(new RegisterPaymentToBankAccountCommand(request.BankAccountId, request.Amount, request.Date));

        return Ok(response);
    }
}