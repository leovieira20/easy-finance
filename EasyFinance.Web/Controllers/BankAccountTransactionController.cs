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
    public async Task<IList<BankAccountTransactionDtoPublicModel>> Get([FromQuery] ShowBankAccountTransactionsRequest request)
    {
        var transactions = await _mediator.Send(new ShowBankAccountTransactionHistoryCommand(request.BankAccountId));

        return transactions.Select(x => x.AdaptToPublicModel()).ToList();
    }
}