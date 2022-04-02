using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BankAccountModule.Application.GetBankAccountOverview;
using EasyFinance.Web.Tests.Integration.Infrastructure.Web;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Clients;

public class BankAccountOverviewClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "/BankAccountOverview";

    public BankAccountOverviewClient(CustomWebApplicationFactory<Program> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    public async Task<(List<MonthlyBreakdownDto>? bankAccountOverview, HttpResponseMessage response)> GetOverviewAsync(Guid bankAccountId, int months)
    {
        var startDate = DateTime.UtcNow;
        var endDate = startDate.AddMonths(months);

        var uri = $"{BaseUrl}?Id={bankAccountId}&StartDate={startDate}&EndDate={endDate}";
        var response = await _httpClient.GetAsync(uri);

        return response.IsSuccessStatusCode switch
        {
            false => (null, response),
            _ => (await response.Content.ReadFromJsonAsync<List<MonthlyBreakdownDto>>(), response)
        };
    }
}