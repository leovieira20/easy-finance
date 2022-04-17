using System.Threading.Tasks;
using BankAccountModule.Domain;
using BankAccountModule.Api.Tests.Integration.Infrastructure.Clients;
using BankAccountModule.Api.Tests.Integration.Infrastructure.Consts;
using TechTalk.SpecFlow;

namespace BankAccountModule.Api.Tests.Integration.Steps;

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