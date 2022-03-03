using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EasyFinance.Application.CreditCardCommands.Overview;
using EasyFinance.Web.Tests.Integration.Infrastructure.Web;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Clients;

public class CreditCardOverviewClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "/CreditCardOverview";

    public CreditCardOverviewClient(CustomWebApplicationFactory<Program> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    public async Task<(CreditCardOverviewDto? overview, HttpResponseMessage response)> Get(DateTime startDate, DateTime endDate)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}?startDate={startDate}&endDate={endDate}");

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<CreditCardOverviewDto>(), response)
        };
    }
}