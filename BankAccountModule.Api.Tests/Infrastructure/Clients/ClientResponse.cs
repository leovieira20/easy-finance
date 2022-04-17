using System.Net.Http;

namespace BankAccountModule.Api.Tests.Integration.Infrastructure.Clients;

public record ClientResponse<T>(T? ParsedPayload, HttpResponseMessage Response);