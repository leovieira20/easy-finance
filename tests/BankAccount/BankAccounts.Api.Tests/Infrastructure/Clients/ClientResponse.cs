using System.Net.Http;

namespace BankAccounts.Api.Tests.Infrastructure.Clients;

public record ClientResponse<T>(T? ParsedPayload, HttpResponseMessage Response);