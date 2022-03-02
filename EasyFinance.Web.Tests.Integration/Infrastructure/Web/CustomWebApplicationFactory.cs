using EasyFinance.Application.Account.RegisterBankAccount;
using EasyFinance.Application.BankAccount.RegisterBankAccount;
using EasyFinance.Domain.Accounts;
using EasyFinance.Web.Tests.Integration.Infrastructure.Db;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Web;

public class CustomWebApplicationFactory<Program> : WebApplicationFactory<Program> where Program: class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                InMemoryDbContextOptionsExtensions.UseInMemoryDatabase(options, "InMemoryDbForTesting");
            });

            services.AddMediatR(typeof(RegisterBankAccountCommandHandler));
            services.AddScoped<IBankAccountRepository, InMemoryEfBankAccountRepository>();
            services.AddScoped<IBankAccountTransactionRepository, InMemoryEfBankAccountTransactionRepository>();
            
            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ApplicationDbContext>();

            db.Database.EnsureCreated();
        });
    }
}