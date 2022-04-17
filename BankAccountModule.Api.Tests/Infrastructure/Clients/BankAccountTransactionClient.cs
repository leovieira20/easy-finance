using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BankAccountModule.Application.GetBankAccountTransactions;
using BankAccountModule.Application.RegisterDepositToBankAccount;
using BankAccountModule.Api.Models.Input;
using BankAccountModule.Api.Tests.Integration.Infrastructure.Web;

namespace BankAccountModule.Api.Tests.Integration.Infrastructure.Clients;

public class BankAccountTransactionClient
{
    private const string BaseUrl = "/BankAccountTransaction";
    private readonly HttpClient _httpClient;

    public BankAccountTransactionClient(CustomWebApplicationFactory<BankAccountModuleProgram> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    public async Task<(IList<BankAccountTransactionDto>? transactions, HttpResponseMessage response)>
        ShowBankAccountTransactionsAsync(Guid bankAccountId)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}?BankAccountId={bankAccountId}");

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<IList<BankAccountTransactionDto>>(), response)
        };
    }

    public async Task<(BankAccountSummaryDto? summary, HttpResponseMessage response)> RegisterDepositToAccountAsync(Guid bankAccountId, decimal amount, int month)
    {
        var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/RegisterDeposit",
            new RegisterBankAccountCreditRequest
            {
                BankAccountId = bankAccountId,
                Amount = amount,
                Date = DateTime.UtcNow.AddMonths(month)
            });

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<BankAccountSummaryDto>(), response)
        };
    }
    
    public async Task<(BankAccountSummaryDto? summary, HttpResponseMessage response)> RegisterPaymentToAccountAsync(Guid bankAccountId, decimal amount, DateTime transactionDate)
    {
        var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/RegisterPayment",
            new RegisterBankAccountDebitRequest
            {
                BankAccountId = bankAccountId,
                Amount = amount,
                Date = transactionDate
            });

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<BankAccountSummaryDto>(), response)
        };
    }
}