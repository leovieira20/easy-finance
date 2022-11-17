using System.Net.Http;

namespace CreditCards.Api.Tests.Infrastructure.Clients;

public record ClientResponse<T>(T? ParsedPayload, HttpResponseMessage Response);