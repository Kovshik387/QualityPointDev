using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QualityPointDev.Services.Settings.SettingsConfigure;

namespace QualityPointDev.Services.Settings;

public static class Bootstrapper
{
    public static IServiceCollection AddCorsSettings(this IServiceCollection services, IConfiguration configuration = null!)
    {
        var settings = QualityPointDev.Settings.Settings.Load<CorsSettings>("Cors", configuration);
        services.AddSingleton(settings);

        return services;
    }
    
    public static IServiceCollection AddDadataApiSettings(this IServiceCollection services, IConfiguration configuration = null!)
    {
        var settings = QualityPointDev.Settings.Settings.Load<DadataApiSettings>("DadataApi", configuration);
        services.AddSingleton(settings);

        return services;
    }
}