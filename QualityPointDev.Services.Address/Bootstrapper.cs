using Microsoft.Extensions.DependencyInjection;
using QualityPointDev.Services.Address.Infrastructure;
using QualityPointDev.Services.Address.Services;

namespace QualityPointDev.Services.Address;

public static class Bootstrapper
{
    public static IServiceCollection AddAddressService(this IServiceCollection services)
    {
        services.AddTransient<IAddressService, AddressService>();
        return services;
    }
}