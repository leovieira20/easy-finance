using BankAccounts.Domain.Aggregates.BankAccountAggregate;
using BankAccounts.Domain.Aggregates.BankAccountTransactionAggregate;
using BankAccounts.Db.SqlServer.EF;
using Db.SqlServer.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccounts.Db.SqlServer;

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