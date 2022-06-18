using BankAccountModule.Domain;
using BankAccountModule.Domain.Repositories;
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