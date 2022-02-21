using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EasyFinance.Application.Account.RegisterBankAccount;
using EasyFinance.Application.Account.RegisterDepositToBankAccount;
using EasyFinance.Web.Models.Input;

namespace EasyFinance.Web.Tests.Integration.Helpers.Clients;

public static class BankAccountClient
{
    private const string BaseUrl = "/BankAccount";

    public static async Task<(BankAccountDtoPublicModel? bankAccount, HttpResponseMessage response)> RegisterBankAccountAsync(HttpClient client, string accountName)
    {
        var bodyParams = new RegisterBankAccountRequest
        {
            Name = accountName
        };
        
        var response = await client.PostAsJsonAsync($"{BaseUrl}/Register", bodyParams);

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<BankAccountDtoPublicModel>(), response)
        };
    }

    public static async Task<(BankAccountSummaryDtoPublicModel? summary, HttpResponseMessage response)> RegisterDepositToAccountAsync(HttpClient client, Guid bankAccountId, decimal amount)
    {
        var response = await client.PostAsJsonAsync($"{BaseUrl}/RegisterDeposit", new RegisterDepositToBankAccountRequest
        {
            BankAccountId = bankAccountId,
            Amount = amount
        });

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<BankAccountSummaryDtoPublicModel>(), response)
        };
    }
}