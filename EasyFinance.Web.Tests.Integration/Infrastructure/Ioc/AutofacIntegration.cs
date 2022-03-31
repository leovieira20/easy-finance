using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using EasyFinance.Db.SqlServer;
using EasyFinance.Db.SqlServer.EF;
using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;
using EasyFinance.Web.Tests.Integration.Infrastructure.Clients;
using EasyFinance.Web.Tests.Integration.Infrastructure.Web;
using EasyFinance.Web.Tests.Integration.Steps;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Ioc;

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
        var dbContextOptions = new DbContextOptions<EasyFinanceDbContext>(dbContextOptionsExtensions);
        
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<EasyFinanceDbContext>(dbContextOptions)
            .UseInMemoryDatabase("InMemoryDbForTesting");
        
        builder
            .RegisterType<EasyFinanceDbContext>()
            .WithParameter("options", dbContextOptionsBuilder.Options)
            .InstancePerLifetimeScope();

        builder.RegisterType<WebApplicationFactory<Program>>().SingleInstance();
        builder.RegisterType<CustomWebApplicationFactory<Program>>().SingleInstance();

        builder.RegisterType<BankAccountClient>().SingleInstance();
        builder.RegisterType<BankAccountOverviewClient>().SingleInstance();
        builder.RegisterType<BankAccountTransactionClient>().SingleInstance();
        builder.RegisterType<CreditCardClient>().SingleInstance();
        builder.RegisterType<CreditCardOverviewClient>().SingleInstance();
        builder.RegisterType<CreditCardSettingsClient>().SingleInstance();

        builder.RegisterType<CreditCardRepository>().As<ICreditCardRepository>().SingleInstance();
        builder.RegisterType<CreditCardTransactionRepository>().As<ICreditCardTransactionRepository>().SingleInstance();

        return builder;
    }
}