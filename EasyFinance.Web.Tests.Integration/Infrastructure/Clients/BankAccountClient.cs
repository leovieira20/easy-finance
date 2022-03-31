using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EasyFinance.Application.BankAccountCommands.RegisterBankAccount;
using EasyFinance.Web.Models.Input;
using EasyFinance.Web.Models.Output;
using EasyFinance.Web.Tests.Integration.Infrastructure.Web;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Clients;

public class BankAccountClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "/BankAccount";

    public BankAccountClient(CustomWebApplicationFactory<Program> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    public async Task<(BankAccountDtoPublicModel? bankAccount, HttpResponseMessage response)> RegisterBankAccountAsync(
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
            _ => (await response.Content.ReadFromJsonAsync<BankAccountDtoPublicModel>(), response)
        };
    }
}