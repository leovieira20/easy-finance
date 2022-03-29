using EasyFinance.Application.BankAccountCommands.RegisterBankAccount;
using EasyFinance.Db.SqlServer;
using EasyFinance.Db.SqlServer.EF;
using EasyFinance.Domain;
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

builder.Services.AddDbContext<ApplicationDbContext>(options =>
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

using (var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
{
    dbContext.Database.EnsureDeleted();
    dbContext.Database.Migrate();

    var bankAccount = BankAccount.Create("Test bank account");
    
    dbContext.BankAccounts.Add(bankAccount);
    dbContext.SaveChanges();
    
    bankAccount.RegisterPayment(1, DateTime.UtcNow);
    
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