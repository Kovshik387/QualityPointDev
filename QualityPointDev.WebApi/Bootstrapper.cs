using QualityPointDev.Services.Address;
using QualityPointDev.Services.Settings;
using QualityPointDev.WebApi.Configuration;

namespace QualityPointDev.WebApi;

public static class Bootstrapper
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration = null)
    {
        return services
            .AddCorsSettings()
            .AddDadataApiSettings()
            .AddHttpClientConfiguration()
            .AddAddressService()
            ;
    }
}