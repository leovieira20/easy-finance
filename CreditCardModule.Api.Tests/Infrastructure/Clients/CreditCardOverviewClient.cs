using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CreditCardModule.Api.Tests.Infrastructure.Web;
using CreditCardModule.Application.Overview;
using CreditCardModule.Domain;

namespace CreditCardModule.Api.Tests.Infrastructure.Clients;

public class CreditCardOverviewClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "/CreditCardOverview";

    public CreditCardOverviewClient(CustomWebApplicationFactory<CreditCardModuleProgram> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    public async Task<(IEnumerable<CreditCardMonthlyBreakdownDto>? overview, HttpResponseMessage response)> Get(CreditCardId creditCardId, DateTime startDate, DateTime endDate)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{creditCardId}?startDate={startDate}&endDate={endDate}");

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<IEnumerable<CreditCardMonthlyBreakdownDto>>(), response)
        };
    }
}