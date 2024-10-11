using QualityPointDev.Helpers;

namespace QualityPointDev.WebApi.Configuration;

public static class AutoMapperConfiguration
{
    public static IServiceCollection AddAppAutoMappers(this IServiceCollection services)
    {
        AutoMapperHelper.Register(services);
        return services;
    }
}