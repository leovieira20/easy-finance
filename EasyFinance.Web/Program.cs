using EasyFinance.Application.BankAccountCommands.RegisterBankAccount;
using EasyFinance.Db.SqlServer;
using EasyFinance.Db.SqlServer.EF;
using EasyFinance.Domain.Accounts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// var seqServerProtocol = builder.Configuration["SERVICE:SEQ:PROTOCOL"];
// var seqServerHost = builder.Configuration["SERVICE:SEQ:HOST"];
// var seqServerPort = builder.Configuration["SERVICE:SEQ:PORT"];
// var seqServerUrl = $"{seqServerProtocol}://{seqServerHost}:{seqServerPort}";

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    // .WriteTo.Seq(seqServerUrl)
    .Enrich.WithProperty("ApplicationName", "EasyFinance.Web")
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDbContext<EasyFinanceDbContext>(options =>
{
    options
        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
        .UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(RegisterBankAccountCommand));

SqlServerModuleBootstrapper.RegisterDependencies(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsEnvironment("IntegrationTests"))
{
    using var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<EasyFinanceDbContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.Migrate();

    var bankAccount = BankAccount.Create(new BankAccountId(Guid.Parse("5395CE24-2C9A-4DDD-8838-52D02890CEC1")),
        "Test bank account");

    dbContext.BankAccounts.Add(bankAccount);
    dbContext.SaveChanges();

    bankAccount.RegisterPayment(1, new DateTime(2022, 01, 01));

    dbContext.SaveChanges();
}

app.MapControllers();
app.Run();

namespace EasyFinance.Web
{
    public partial class Program
    {
    }
}