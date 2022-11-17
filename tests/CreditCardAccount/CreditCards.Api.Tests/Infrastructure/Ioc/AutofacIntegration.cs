using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using CreditCards.Api.Tests.Infrastructure.Clients;
using CreditCards.Api.Tests.Infrastructure.Web;
using CreditCards.Api.Tests.Steps;
using CreditCards.Db.SqlServer;
using CreditCards.Db.SqlServer.EF;
using CreditCards.Domain;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace CreditCards.Api.Tests.Infrastructure.Ioc;

public class AutofacIntegration
{
    [ScenarioDependencies]
    public static ContainerBuilder CreateContainerBuilder()
    {
        var builder = new ContainerBuilder();

        builder
            .RegisterTypes(typeof(CreditCardOverviewStepDefinitions).Assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute)))
                .ToArray())
            .SingleInstance();

        var dbContextOptionsExtensions = new Dictionary<Type, IDbContextOptionsExtension>();
        var dbContextOptions = new DbContextOptions<CreditCardsDbContext>(dbContextOptionsExtensions);
        
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<CreditCardsDbContext>(dbContextOptions)
            .UseInMemoryDatabase("InMemoryDbForTesting");
        
        builder
            .RegisterType<CreditCardsDbContext>()
            .WithParameter("options", dbContextOptionsBuilder.Options)
            .InstancePerLifetimeScope();

        builder.RegisterType<WebApplicationFactory<CreditCardModuleProgram>>().SingleInstance();
        builder.RegisterType<CustomWebApplicationFactory<CreditCardModuleProgram>>().SingleInstance();
        
        builder.RegisterType<CreditCardClient>().SingleInstance();
        builder.RegisterType<CreditCardOverviewClient>().SingleInstance();
        builder.RegisterType<CreditCardSettingsClient>().SingleInstance();

        builder.RegisterType<CreditCardRepository>().As<ICreditCardRepository>().SingleInstance();
        builder.RegisterType<CreditCardTransactionRepository>().As<ICreditCardTransactionRepository>().SingleInstance();

        return builder;
    }
}