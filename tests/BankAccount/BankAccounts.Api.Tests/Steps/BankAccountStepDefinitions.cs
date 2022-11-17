using System.Threading.Tasks;
using BankAccounts.Api.Tests.Infrastructure.Clients;
using BankAccounts.Api.Tests.Infrastructure.Consts;
using BankAccounts.Domain.Aggregates.BankAccountAggregate;
using TechTalk.SpecFlow;

namespace BankAccounts.Api.Tests.Steps;

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