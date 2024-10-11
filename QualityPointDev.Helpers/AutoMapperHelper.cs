using Microsoft.Extensions.DependencyInjection;

namespace QualityPointDev.Helpers;

public static class AutoMapperHelper
{
    public static void Register(IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(s => s.FullName != null && s.FullName.ToLower().StartsWith("qualitypointdev."));
        services.AddAutoMapper(assemblies);
    }
}