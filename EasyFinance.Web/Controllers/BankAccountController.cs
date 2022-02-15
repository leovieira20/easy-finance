using EasyFinance.Application.Account.RegisterBankAccount;
using EasyFinance.Web.Models.Input;
using EasyFinance.Web.Models.Output;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinance.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class BankAccountController : ControllerBase
{
    private readonly ILogger<BankAccountController> _logger;
    private readonly IMediator _mediator;

    public BankAccountController(ILogger<BankAccountController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<BankAccountPublicModel> RegisterAccount([FromBody] RegisterBankAccountRequest request)
    {
        var response = await _mediator.Send(new RegisterBankAccountCommand(request.Name));

        //TODO: use Mapster.Tool whenever it's ready for net6
        return response.Adapt<BankAccountPublicModel>();
    }
}