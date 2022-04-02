using CreditCardModule.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace CreditCardModule.Db.SqlServer;

public static class CreditCardSqlServerModuleBootstrapper
{
    public static void RegisterDependencies(IServiceCollection services)
    {
        services.AddScoped<ICreditCardRepository, CreditCardRepository>();
        services.AddScoped<ICreditCardTransactionRepository, CreditCardTransactionRepository>();
    }
}