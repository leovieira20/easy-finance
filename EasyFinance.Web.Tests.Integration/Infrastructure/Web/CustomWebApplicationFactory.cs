using System;
using System.Linq;
using EasyFinance.Application.BankAccountCommands.RegisterBankAccount;
using EasyFinance.Db.SqlServer;
using EasyFinance.Db.SqlServer.EF;
using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Web;

public class CustomWebApplicationFactory<Program> : WebApplicationFactory<Program> where Program: class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("IntegrationTests");
        
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services
                .SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<EasyFinanceDbContext>));
            services.Remove(dbContextDescriptor!);
            
            services.AddDbContext<EasyFinanceDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });
            
            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<EasyFinanceDbContext>();

            db.Database.EnsureCreated();
        });
    }
}