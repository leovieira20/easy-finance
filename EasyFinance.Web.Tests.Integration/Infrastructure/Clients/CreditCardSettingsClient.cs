using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EasyFinance.Domain.Accounts;
using EasyFinance.Web.Tests.Integration.Infrastructure.Web;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Clients;

public class CreditCardSettingsClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "/CreditCardSettings";

    public CreditCardSettingsClient(CustomWebApplicationFactory<Program> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    public async Task<ClientResponse<CreditCardSettingsPublicModel>> SetLimitAsync(Guid creditCardId, decimal limit)
    {
        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/SetLimit/{creditCardId}", limit);

        return response.IsSuccessStatusCode switch
        {
            false => new ClientResponse<CreditCardSettingsPublicModel>(null, response),
            _ => new ClientResponse<CreditCardSettingsPublicModel>(await response.Content.ReadFromJsonAsync<CreditCardSettingsPublicModel>(), response)
        };
    }

    public async Task<ClientResponse<CreditCardSettingsPublicModel>> SetThresholdAsync(Guid creditCardId, int amount)
    {
        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/SetThreshold/{creditCardId}", amount);

        return response.IsSuccessStatusCode switch
        {
            false => new ClientResponse<CreditCardSettingsPublicModel>(null, response),
            _ => new ClientResponse<CreditCardSettingsPublicModel>(await response.Content.ReadFromJsonAsync<CreditCardSettingsPublicModel>(), response)
        };
    }

    public async Task<ClientResponse<CreditCardSettingsPublicModel>> SetDefaultPaymentAmountAsync(Guid creditCardId, int amount)
    {
        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/SetDefaultPaymentAmount/{creditCardId}", amount);

        return response.IsSuccessStatusCode switch
        {
            false => new ClientResponse<CreditCardSettingsPublicModel>(null, response),
            _ => new ClientResponse<CreditCardSettingsPublicModel>(await response.Content.ReadFromJsonAsync<CreditCardSettingsPublicModel>(), response)
        };
    }
}