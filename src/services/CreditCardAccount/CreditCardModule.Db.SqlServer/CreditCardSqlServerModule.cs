using CreditCardModule.Db.SqlServer.EF;
using CreditCardModule.Domain;
using Db.SqlServer.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CreditCardModule.Db.SqlServer;

public static class CreditCardSqlServerModule
{
    public static void RegisterDependencies(IServiceCollection services)
    {
        services.AddScoped<ICreditCardRepository, CreditCardRepository>();
        services.AddScoped<ICreditCardTransactionRepository, CreditCardTransactionRepository>();
    }
    
    public static WebApplicationBuilder RegisterCreditCardAccountSqlServer(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<CreditCardsDbContext>(options =>
        {
            options
                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                .UseSqlServer(builder.Configuration.GetConnectionString("default"));
        });
        
        builder.Services.AddScoped<ICreditCardRepository, CreditCardRepository>();
        builder.Services.AddScoped<ICreditCardTransactionRepository, CreditCardTransactionRepository>();

        return builder;
    }
}