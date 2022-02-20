using EasyFinance.Application.Account.RegisterBankAccount;
using EasyFinance.Application.Account.RegisterDepositToBankAccount;
using EasyFinance.Web.Models.Input;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinance.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class BankAccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public BankAccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<BankAccountDtoPublicModel> RegisterAccount([FromBody] RegisterBankAccountRequest request)
    {
        var response = await _mediator.Send(new RegisterBankAccountCommand(request.Name));

        return response.AdaptToPublicModel();
    }
    
    [HttpPost("RegisterDeposit")]
    public async Task<BankAccountSummaryDtoPublicModel> RegisterDeposit([FromBody] RegisterDepositToBankAccountRequest request)
    {
        var response = await _mediator.Send(new RegisterDepositToBankAccountCommand(request.BankAccountId, request.Amount));

        return response.AdaptToPublicModel();
    }
}