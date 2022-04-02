using BankAccountModule.Domain;
using NSubstitute;

namespace EasyFinance.Application.Tests.Acceptance.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario("bankAccount")]
        public void SetupBankAccountRepository(ScenarioContext context)
        {
            context.Add(nameof(IBankAccountRepository), Substitute.For<IBankAccountRepository>());
        }
    }
}