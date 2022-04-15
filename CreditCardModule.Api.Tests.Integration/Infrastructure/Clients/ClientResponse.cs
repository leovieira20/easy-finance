using System.Net.Http;

namespace CreditCardModule.Api.Tests.Integration.Infrastructure.Clients;

public record ClientResponse<T>(T? ParsedPayload, HttpResponseMessage Response);