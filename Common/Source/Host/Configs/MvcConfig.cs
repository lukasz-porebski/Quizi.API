using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Common.Host.Configs;

internal static class MvcConfig
{
    public static IServiceCollection AddMvc(this IServiceCollection services, BaseAssemblies assemblies)
    {
        services.AddMvc()
            .AddApplicationPart(assemblies.Host)
            .AddDefaultJsonOptions();

        services
            .AddHttpContextAccessor();

        return services;
    }

    private static IMvcBuilder AddDefaultJsonOptions(this IMvcBuilder builder) =>
        builder.AddNewtonsoftJson(o =>
        {
            o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            o.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            o.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
            o.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            o.SerializerSettings.Formatting = Formatting.Indented;
            o.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            o.SerializerSettings.Converters.Add(new StringEnumConverter());
        });
}