using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CreditCards.Api.Tests.Infrastructure.Web;
using CreditCards.Domain;

namespace CreditCards.Api.Tests.Infrastructure.Clients;

public class CreditCardSettingsClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "/CreditCardSettings";

    public CreditCardSettingsClient(CustomWebApplicationFactory<CreditCardModuleProgram> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    public async Task<ClientResponse<CreditCardSettings>> SetLimitAsync(Guid creditCardId, decimal limit)
    {
        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/SetLimit/{creditCardId}", limit);

        return response.IsSuccessStatusCode switch
        {
            false => new(null, response),
            _ => new(await response.Content.ReadFromJsonAsync<CreditCardSettings>(), response)
        };
    }

    public async Task<ClientResponse<CreditCardSettings>> SetThresholdAsync(Guid creditCardId, int amount)
    {
        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/SetThreshold/{creditCardId}", amount);

        return response.IsSuccessStatusCode switch
        {
            false => new(null, response),
            _ => new(await response.Content.ReadFromJsonAsync<CreditCardSettings>(), response)
        };
    }

    public async Task<ClientResponse<CreditCardSettings>> SetDefaultPaymentAmountAsync(Guid creditCardId, int amount)
    {
        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/SetDefaultPaymentAmount/{creditCardId}", amount);

        return response.IsSuccessStatusCode switch
        {
            false => new(null, response),
            _ => new(await response.Content.ReadFromJsonAsync<CreditCardSettings>(), response)
        };
    }
}