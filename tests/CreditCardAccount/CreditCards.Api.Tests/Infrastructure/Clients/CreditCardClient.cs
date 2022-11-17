using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CreditCards.Api.Models.Input;
using CreditCards.Api.Tests.Infrastructure.Web;
using CreditCards.Application.Models;

namespace CreditCards.Api.Tests.Infrastructure.Clients;

public class CreditCardClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "/CreditCard";

    public CreditCardClient(CustomWebApplicationFactory<CreditCardModuleProgram> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    public async Task<(CreditCardDto? bankAccount, HttpResponseMessage response)> Register(string cardName)
    {
        var bodyParams = new RegisterCreditCardRequest
        {
            Name = cardName
        };

        var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/Register", bodyParams);

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<CreditCardDto>(), response)
        };
    }
}