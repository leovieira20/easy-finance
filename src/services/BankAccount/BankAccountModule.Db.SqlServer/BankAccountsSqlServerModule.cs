using BankAccountModule.Db.SqlServer.EF;
using BankAccountModule.Domain;
using Db.SqlServer.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccountModule.Db.SqlServer;

public static class BankAccountsSqlServerModule
{
    public static void RegisterDependencies(IServiceCollection services)
    {
        services.AddScoped<IBankAccountRepository, BankAccountRepository>();
        services.AddScoped<IBankAccountTransactionRepository, BankAccountTransactionRepository>();
    }

    public static WebApplicationBuilder RegisterBankAccountSqlServer(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<BankAccountsDbContext>(options =>
        {
            options
                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                .UseSqlServer(builder.Configuration.GetConnectionString("default"));
        });
        
        builder.Services.AddScoped<IBankAccountRepository, BankAccountRepository>();
        builder.Services.AddScoped<IBankAccountTransactionRepository, BankAccountTransactionRepository>();

        return builder;
    }
}