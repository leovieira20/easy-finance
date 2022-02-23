using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EasyFinance.Application.Account.RegisterBankAccount;
using EasyFinance.Application.Account.RegisterDepositToBankAccount;
using EasyFinance.Web.Models.Input;
using EasyFinance.Web.Tests.Integration.Infrastructure.Web;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Clients;

public class BankAccountClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "/BankAccount";

    public BankAccountClient(CustomWebApplicationFactory<Program> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    public async Task<(BankAccountDtoPublicModel? bankAccount, HttpResponseMessage response)> RegisterBankAccountAsync(string accountName)
    {
        var bodyParams = new RegisterBankAccountRequest
        {
            Name = accountName
        };
        
        var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/Register", bodyParams);

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<BankAccountDtoPublicModel>(), response)
        };
    }

    public async Task<(BankAccountSummaryDtoPublicModel? summary, HttpResponseMessage response)> RegisterDepositToAccountAsync(Guid bankAccountId, decimal amount, int month)
    {
        var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/RegisterDeposit", new RegisterDepositToBankAccountRequest
        {
            BankAccountId = bankAccountId,
            Amount = amount,
            Date = DateTime.UtcNow.AddMonths(month)
        });

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<BankAccountSummaryDtoPublicModel>(), response)
        };
    }
}