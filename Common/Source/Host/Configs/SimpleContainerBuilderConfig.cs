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
            .Concat(typeof(DateTimeProvider).Assembly.GetTypes())
            .Except([typeof(MessageProvider)])
            .Where(t => t.IsProvider())
            .ToArray();
        builder.RegisterTypes(types).AsImplementedInterfaces();
        return builder;
    }

    public static ContainerBuilder RegisterFactories(this ContainerBuilder builder, BaseAssemblies assemblies)
    {
        var types = assemblies.GetAllTypes()
            .Concat(typeof(DateTimeProvider).Assembly.GetTypes())
            .Where(t => t.IsFactory())
            .ToArray();
        builder.RegisterTypes(types).AsImplementedInterfaces();
        return builder;
    }

    public static ContainerBuilder RegisterUtils(this ContainerBuilder builder)
    {
        builder.RegisterType<Hasher>().AsImplementedInterfaces();
        return builder;
    }

    public static ContainerBuilder RegisterReadModels(this ContainerBuilder builder, BaseAssemblies assemblies)
    {
        var types = assemblies.InfrastructureReadModels
            .GetExportedTypes()
            .Where(t => t.IsReadModel())
            .ToArray();
        builder.RegisterTypes(types).AsImplementedInterfaces();
        return builder;
    }
}