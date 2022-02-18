using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EasyFinance.Web.Models.Input;
using EasyFinance.Web.Models.Output;

namespace EasyFinance.Web.Tests.Integration.Helpers.Clients;

public class BankAccountClient
{
    private const string BaseUrl = "/BankAccount";

    public static async Task<BankAccountPublicModel?> RegisterBankAccountAsync(HttpClient client, string accountName)
    {
        var bodyParams = new RegisterBankAccountRequest
        {
            Name = accountName
        };
        
        var response = await client.PostAsJsonAsync($"{BaseUrl}/Register", bodyParams);
        
        return await response.Content.ReadFromJsonAsync<BankAccountPublicModel>();
    }

    public static async Task<BankAccountSummaryPublicModel?> AddFundsToAccountAsync(HttpClient client, Guid bankAccountId, decimal amount)
    {
        var response = await client.PostAsJsonAsync($"{BaseUrl}/AddFunds", new AddFundsToBankAccountRequest
        {
            BankAccountId = bankAccountId,
            Amount = amount
        });

        return await response.Content.ReadFromJsonAsync<BankAccountSummaryPublicModel>();
    }
}