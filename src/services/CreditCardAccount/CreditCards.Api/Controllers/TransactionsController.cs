using CreditCards.Application;
using CreditCards.Api.Models.Input;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCards.Api.Controllers;

[Route("[controller]")]
public class TransactionsController : Controller
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromBody] GetTransactionsRequest request)
    {
        var result = await _mediator.Send(new GetCreditCardTransactions.Query(request.CreditCardId, request.StartDate, request.EndDate));
        return Ok(result);
    }
}