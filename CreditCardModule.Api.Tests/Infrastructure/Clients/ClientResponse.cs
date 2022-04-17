using System.Net.Http;

namespace CreditCardModule.Api.Tests.Infrastructure.Clients;

public record ClientResponse<T>(T? ParsedPayload, HttpResponseMessage Response);