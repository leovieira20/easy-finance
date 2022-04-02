using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CreditCardModule.Application.Register;
using EasyFinance.Web.Models.Input;
using EasyFinance.Web.Tests.Integration.Infrastructure.Web;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Clients;

public class CreditCardClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "/CreditCard";

    public CreditCardClient(CustomWebApplicationFactory<Program> webApplicationFactory)
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