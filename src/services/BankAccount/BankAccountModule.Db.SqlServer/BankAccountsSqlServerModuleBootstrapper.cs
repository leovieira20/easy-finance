using BankAccountModule.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccountModule.Db.SqlServer;

public static class BankAccountsSqlServerModuleBootstrapper
{
    public static void RegisterDependencies(IServiceCollection services)
    {
        services.AddScoped<IBankAccountRepository, BankAccountRepository>();
        services.AddScoped<IBankAccountTransactionRepository, BankAccountTransactionRepository>();
    }
}