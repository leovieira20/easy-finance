using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CreditCardModule.Domain;
using CreditCardModule.Api.Tests.Integration.Infrastructure.Web;

namespace CreditCardModule.Api.Tests.Integration.Infrastructure.Clients;

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
            false => new ClientResponse<CreditCardSettings>(null, response),
            _ => new ClientResponse<CreditCardSettings>(await response.Content.ReadFromJsonAsync<CreditCardSettings>(), response)
        };
    }

    public async Task<ClientResponse<CreditCardSettings>> SetThresholdAsync(Guid creditCardId, int amount)
    {
        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/SetThreshold/{creditCardId}", amount);

        return response.IsSuccessStatusCode switch
        {
            false => new ClientResponse<CreditCardSettings>(null, response),
            _ => new ClientResponse<CreditCardSettings>(await response.Content.ReadFromJsonAsync<CreditCardSettings>(), response)
        };
    }

    public async Task<ClientResponse<CreditCardSettings>> SetDefaultPaymentAmountAsync(Guid creditCardId, int amount)
    {
        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/SetDefaultPaymentAmount/{creditCardId}", amount);

        return response.IsSuccessStatusCode switch
        {
            false => new ClientResponse<CreditCardSettings>(null, response),
            _ => new ClientResponse<CreditCardSettings>(await response.Content.ReadFromJsonAsync<CreditCardSettings>(), response)
        };
    }
}