using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using BankAccountModule.Api.Tests.Infrastructure.Clients;
using BankAccountModule.Api.Tests.Infrastructure.Web;
using BankAccountModule.Api.Tests.Steps;
using BankAccountModule.Db.SqlServer.EF;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace BankAccountModule.Api.Tests.Infrastructure.Ioc;

public class AutofacIntegration
{
    [ScenarioDependencies]
    public static ContainerBuilder CreateContainerBuilder()
    {
        var builder = new ContainerBuilder();

        builder
            .RegisterTypes(typeof(ShowBankAccountBalanceOverTimeStepDefinitions).Assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute)))
                .ToArray())
            .SingleInstance();

        var dbContextOptionsExtensions = new Dictionary<Type, IDbContextOptionsExtension>();
        var dbContextOptions = new DbContextOptions<BankAccountsDbContext>(dbContextOptionsExtensions);
        
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<BankAccountsDbContext>(dbContextOptions)
            .UseInMemoryDatabase("InMemoryDbForTesting");
        
        builder
            .RegisterType<BankAccountsDbContext>()
            .WithParameter("options", dbContextOptionsBuilder.Options)
            .InstancePerLifetimeScope();

        builder.RegisterType<WebApplicationFactory<CreditCardModule.Api.CreditCardModuleProgram>>().SingleInstance();
        builder.RegisterType<CustomWebApplicationFactory<CreditCardModule.Api.CreditCardModuleProgram>>().SingleInstance();

        builder.RegisterType<BankAccountClient>().SingleInstance();
        builder.RegisterType<BankAccountOverviewClient>().SingleInstance();
        builder.RegisterType<BankAccountTransactionClient>().SingleInstance();

        return builder;
    }
}