using System.Threading.Tasks;
using BankAccountModule.Api.Tests.Infrastructure.Clients;
using BankAccountModule.Api.Tests.Infrastructure.Consts;
using BankAccountModule.Domain;
using TechTalk.SpecFlow;

namespace BankAccountModule.Api.Tests.Steps;

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