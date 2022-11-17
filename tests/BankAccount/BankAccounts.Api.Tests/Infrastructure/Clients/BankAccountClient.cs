using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BankAccounts.Api.Models.Input;
using BankAccounts.Api.Tests.Infrastructure.Web;
using BankAccounts.Application.Models;

namespace BankAccounts.Api.Tests.Infrastructure.Clients;

public class BankAccountClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "/BankAccount";

    public BankAccountClient(CustomWebApplicationFactory<BankAccountModuleProgram> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    public async Task<(BankAccountDto? bankAccount, HttpResponseMessage response)> RegisterBankAccountAsync(
        string accountName)
    {
        var bodyParams = new RegisterBankAccountRequest
        {
            Name = accountName
        };

        var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/Register", bodyParams);

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<BankAccountDto>(), response)
        };
    }
}