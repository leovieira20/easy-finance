using CreditCardModule.Api.Models.Input;
using CreditCardModule.Application.GetTransactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardModule.Api.Controllers;

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
        var result = await _mediator.Send(new GetTransactionsCommand(request.CreditCardId, request.StartDate, request.EndDate));
        return Ok(result);
    }
}