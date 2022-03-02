using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EasyFinance.Application.Account.RegisterDepositToBankAccount;
using EasyFinance.Application.Account.ShowBankAccountTransactions;
using EasyFinance.Web.Models.Input;
using EasyFinance.Web.Tests.Integration.Infrastructure.Web;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Clients;

public class BankAccountTransactionClient
{
    private const string BaseUrl = "/BankAccountTransaction";
    private readonly HttpClient _httpClient;

    public BankAccountTransactionClient(CustomWebApplicationFactory<Program> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    public async Task<(IList<BankAccountTransactionDtoPublicModel>? transactions, HttpResponseMessage response)>
        ShowBankAccountTransactionsAsync(Guid bankAccountId)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}?BankAccountId={bankAccountId}");

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<IList<BankAccountTransactionDtoPublicModel>>(), response)
        };
    }

    public async Task<(BankAccountSummaryDtoPublicModel? summary, HttpResponseMessage response)>
        RegisterDepositToAccountAsync(Guid bankAccountId, decimal amount, int month)
    {
        var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/RegisterDeposit",
            new RegisterDepositToBankAccountRequest
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