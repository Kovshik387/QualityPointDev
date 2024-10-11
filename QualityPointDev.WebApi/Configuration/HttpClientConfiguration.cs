using QualityPointDev.Services.Address.Infrastructure;

namespace QualityPointDev.WebApi.Configuration;

public static class HttpClientConfiguration
{
    public static IServiceCollection AddHttpClientConfiguration(this IServiceCollection services)
    {
        services.AddHttpClient<IAddressService>(client =>
        {
            client.Timeout = TimeSpan.FromSeconds(50);
        });
        return services;
    }
}