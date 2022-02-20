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

    public static async Task<IList<BankAccountTransactionDtoPublicModel>?> ShowBankAccountTransactionsAsync(HttpClient client, Guid bankAccountId)
    {
        return await client.GetFromJsonAsync<IList<BankAccountTransactionDtoPublicModel>>($"{BaseUrl}?BankAccountId={bankAccountId}");
    }
}