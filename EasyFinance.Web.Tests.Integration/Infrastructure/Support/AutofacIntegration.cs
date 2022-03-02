using System;
using System.Linq;
using Autofac;
using EasyFinance.Web.Tests.Integration.Infrastructure.Clients;
using EasyFinance.Web.Tests.Integration.Infrastructure.Db;
using EasyFinance.Web.Tests.Integration.Infrastructure.Web;
using EasyFinance.Web.Tests.Integration.Steps;
using Microsoft.AspNetCore.Mvc.Testing;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Support;

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

        builder.RegisterType<ApplicationDbContext>().SingleInstance();

        builder.RegisterType<WebApplicationFactory<Program>>().SingleInstance();
        builder.RegisterType<CustomWebApplicationFactory<Program>>().SingleInstance();

        builder.RegisterType<BankAccountClient>().SingleInstance();
        builder.RegisterType<BankAccountOverviewClient>().SingleInstance();
        builder.RegisterType<BankAccountTransactionClient>().SingleInstance();
        builder.RegisterType<CreditCardClient>().SingleInstance();

        return builder;
    }
}