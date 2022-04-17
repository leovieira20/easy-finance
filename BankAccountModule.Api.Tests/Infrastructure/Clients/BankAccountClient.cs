using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BankAccountModule.Application.RegisterBankAccount;
using BankAccountModule.Api.Models.Input;
using BankAccountModule.Api.Tests.Integration.Infrastructure.Web;

namespace BankAccountModule.Api.Tests.Integration.Infrastructure.Clients;

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