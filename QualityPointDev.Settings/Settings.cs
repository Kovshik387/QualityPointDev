﻿﻿using Microsoft.Extensions.Configuration;

namespace QualityPointDev.Settings;

public abstract class Settings
{
    public static T Load<T>(string key, IConfiguration configuration = null!)
    {
        var settings = (T)Activator.CreateInstance(typeof(T))!;

        SettingsFactory.Create(configuration).GetSection(key)
            .Bind(settings, (x) => { x.BindNonPublicProperties = true; });

        return settings;
    }
}