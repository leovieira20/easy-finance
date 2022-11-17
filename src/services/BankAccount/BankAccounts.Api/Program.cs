using BankAccounts.Application;
using BankAccounts.Db.SqlServer;
using BankAccounts.Db.SqlServer.EF;
using Db.SqlServer.Common;
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

builder.Services.AddDbContext<BankAccountsDbContext>(options =>
{
    options
        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
        .UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(RegisterBankAccount.Command));

BankAccountsSqlServerModule.RegisterDependencies(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();

namespace BankAccounts.Api
{
    public partial class BankAccountModuleProgram
    {
    }
}