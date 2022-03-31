using EasyFinance.Application.BankAccountTransactionCommands.RegisterDepositToBankAccount;
using EasyFinance.Application.BankAccountTransactionCommands.RegisterPaymentToBankAccount;
using EasyFinance.Application.BankAccountTransactionCommands.ShowBankAccountTransactions;
using EasyFinance.Web.Models.Input;
using EasyFinance.Web.Models.Output;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinance.Web.Controllers;

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

        return Ok(transactions.Select(x => x.AdaptToPublicModel()).ToList());
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterDeposit([FromBody] RegisterDepositToBankAccountRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _mediator
            .Send(new RegisterDepositToBankAccountCommand(request.BankAccountId, request.Amount, request.Date));

        return Ok(response.AdaptToPublicModel());
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterPayment([FromBody] RegisterPaymentToBankAccountRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _mediator
            .Send(new RegisterPaymentToBankAccountCommand(request.BankAccountId, request.Amount, request.Date));

        return Ok(response.AdaptToPublicModel());
    }
}