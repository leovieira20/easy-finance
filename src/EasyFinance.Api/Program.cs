using BankAccounts.Db.SqlServer;
using CreditCards.Db.SqlServer;
using FastEndpoints;
using EasyFinance.Api.Infrastructure.Pipeline;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddSerilog()
    .AddFastEndpoints()
    .AddMediatr()
    .RegisterBankAccountSqlServer()
    .RegisterCreditCardAccountSqlServer()
    .AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFastEndpoints();
app.Run();