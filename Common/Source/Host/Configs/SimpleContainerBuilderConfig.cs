using Autofac;
using Common.Host.Middlewares;
using Common.Host.Providers;
using Common.Host.Utils;
using Microsoft.Extensions.Configuration;

namespace Common.Host.Configs;

internal static class SimpleContainerBuilderConfig
{
    public static ContainerBuilder RegisterConfiguration(this ContainerBuilder builder, IConfiguration configuration)
    {
        builder.RegisterInstance(configuration);
        return builder;
    }

    public static ContainerBuilder RegisterMiddlewares(this ContainerBuilder builder)
    {
        builder.RegisterType<ErrorHandlerMiddleware>().AsSelf();
        return builder;
    }

    public static ContainerBuilder RegisterRepositories(this ContainerBuilder builder, BaseAssemblies assemblies)
    {
        var types = assemblies.InfrastructureDatabaseEf.GetExportedTypes().Where(t => t.IsRepository()).ToArray();
        builder.RegisterTypes(types).AsImplementedInterfaces();
        return builder;
    }

    public static ContainerBuilder RegisterServices(this ContainerBuilder builder, BaseAssemblies assemblies)
    {
        var types = assemblies.GetAllTypes()
            .Where(t => t.IsService())
            .ToArray();
        builder.RegisterTypes(types).AsImplementedInterfaces();
        return builder;
    }

    public static ContainerBuilder RegisterProviders(this ContainerBuilder builder, BaseAssemblies assemblies)
    {
        var types = assemblies.GetAllTypes()
            .Where(t => t.IsProvider())
            .Concat(typeof(DateTimeProvider).Assembly.GetTypes())
            .ToArray();
        builder.RegisterTypes(types).AsImplementedInterfaces();
        return builder;
    }

    public static ContainerBuilder RegisterFactories(this ContainerBuilder builder, BaseAssemblies assemblies)
    {
        var types = assemblies.GetAllTypes()
            .Where(t => t.IsFactory())
            .Concat(typeof(DateTimeProvider).Assembly.GetTypes())
            .ToArray();
        builder.RegisterTypes(types).AsImplementedInterfaces();
        return builder;
    }
}