using BankAccountModule.Application.RegisterDepositToBankAccount;
using BankAccountModule.Application.RegisterPaymentToBankAccount;
using BankAccountModule.Application.ShowBankAccountTransactions;
using EasyFinance.Web.Models.Input;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinance.Web.Controllers.BankAccount;

[Route("[controller]")]
public class BankAccountTransactionController : ControllerBase
{
    private readonly IMediator _mediator;

    public BankAccountTransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ShowBankAccountTransactionsRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var transactions = await _mediator.Send(new ShowBankAccountTransactionHistoryCommand(request.BankAccountId));

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