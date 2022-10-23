using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CreditCardModule.Api.Models.Input;
using CreditCardModule.Api.Tests.Infrastructure.Web;
using CreditCardModule.Application.Register;

namespace CreditCardModule.Api.Tests.Infrastructure.Clients;

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