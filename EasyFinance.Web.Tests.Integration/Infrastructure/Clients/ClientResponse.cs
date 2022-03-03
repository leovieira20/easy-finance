using System.Net.Http;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Clients;

public record ClientResponse<T>(T? ParsedPayload, HttpResponseMessage Response);