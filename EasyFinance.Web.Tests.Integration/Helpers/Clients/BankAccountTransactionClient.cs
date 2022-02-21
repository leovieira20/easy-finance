using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EasyFinance.Application.Account.ShowBankAccountTransactions;

namespace EasyFinance.Web.Tests.Integration.Helpers.Clients;

public static class BankAccountTransactionClient
{
    private const string BaseUrl = "/BankAccountTransaction";

    public static async Task<(IList<BankAccountTransactionDtoPublicModel>? transactions, HttpResponseMessage response)> ShowBankAccountTransactionsAsync(HttpClient client, Guid bankAccountId)
    {
        var response = await client.GetAsync($"{BaseUrl}?BankAccountId={bankAccountId}");

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<IList<BankAccountTransactionDtoPublicModel>>(), response)
        };
    }
}