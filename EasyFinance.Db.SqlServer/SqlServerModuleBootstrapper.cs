using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;
using Microsoft.Extensions.DependencyInjection;

namespace EasyFinance.Db.SqlServer;

public static class SqlServerModuleBootstrapper
{
    public static void RegisterDependencies(IServiceCollection services)
    {
        services.AddScoped<IBankAccountRepository, BankAccountRepository>();
        services.AddScoped<IBankAccountTransactionRepository, BankAccountTransactionRepository>();
        services.AddScoped<ICreditCardRepository, CreditCardRepository>();
        services.AddScoped<ICreditCardTransactionRepository, CreditCardTransactionRepository>();
    }
}