using BankAccounts.Application;
using CreditCards.Application;
using MediatR;

namespace EasyFinance.Api.Infrastructure.Pipeline;

public static class MediatrRegistration
{
    public static WebApplicationBuilder AddMediatr(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(typeof(GetBankAccountOverview.Query).Assembly, typeof(GetCreditCardTransactions.Query).Assembly);

        return builder;
    }
}