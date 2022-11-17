using FastEndpoints;

namespace EasyFinance.Api.Infrastructure.Pipeline;

public static class FastEndpointRegistration
{
    public static WebApplicationBuilder AddFastEndpoints(this WebApplicationBuilder builder)
    {
        builder.Services.AddFastEndpoints();

        return builder;
    }
}