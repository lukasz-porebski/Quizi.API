using Autofac;
using Domain.Modules.Users.Models;
using Infrastructure.Modules.Users;
using Microsoft.AspNetCore.Identity;

namespace Host.StartupConfigs;

internal static class SimpleContainerBuilderConfig
{
    public static ContainerBuilder RegisterUtils(this ContainerBuilder builder)
    {
        builder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>();
        builder.RegisterType<PasswordHasher>().AsImplementedInterfaces();

        return builder;
    }
}