using EasyFinance.Application.Account.ShowBankAccountTransactions;
using EasyFinance.Web.Models.Input;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinance.Web.Controllers;

[Controller]
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
}