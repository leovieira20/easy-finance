using System.Threading.Tasks;
using EasyFinance.Domain.Accounts;
using EasyFinance.Web.Tests.Integration.Infrastructure.Clients;
using EasyFinance.Web.Tests.Integration.Infrastructure.Consts;
using TechTalk.SpecFlow;

namespace EasyFinance.Web.Tests.Integration.Steps;

[Binding]
public class BankAccountStepDefinitions
{
    private readonly ScenarioContext _context;
    private readonly BankAccountClient _client;

    public BankAccountStepDefinitions(ScenarioContext context, BankAccountClient client)
    {
        _context = context;
        _client = client;
    }
    
    [Given(@"existing bank account with default name")]
    public async Task GivenExistingBankAccountWithDefaultName()
    {
        var response = await _client.RegisterBankAccountAsync(BankAccountConsts.DefaultName);
        
        _context.Add(nameof(BankAccount.Id), response.bankAccount!.Id);
    }
}