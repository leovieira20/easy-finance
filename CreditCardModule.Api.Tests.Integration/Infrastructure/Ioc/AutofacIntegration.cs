using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using CreditCardModule.Db.SqlServer;
using CreditCardModule.Domain;
using CreditCardModule.Api.Tests.Integration.Infrastructure.Clients;
using CreditCardModule.Api.Tests.Integration.Infrastructure.Web;
using CreditCardModule.Api.Tests.Integration.Steps;
using Db.SqlServer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace CreditCardModule.Api.Tests.Integration.Infrastructure.Ioc;

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
        var dbContextOptions = new DbContextOptions<EasyFinanceDbContext>(dbContextOptionsExtensions);
        
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<EasyFinanceDbContext>(dbContextOptions)
            .UseInMemoryDatabase("InMemoryDbForTesting");
        
        builder
            .RegisterType<EasyFinanceDbContext>()
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