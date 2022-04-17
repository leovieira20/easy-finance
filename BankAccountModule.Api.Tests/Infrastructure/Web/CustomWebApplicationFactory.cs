using System.Linq;
using Db.SqlServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccountModule.Api.Tests.Integration.Infrastructure.Web;

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