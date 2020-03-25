using System.Reflection;
using Autofac;
using TravelHelper.Core.Repositories;

namespace TravelHelper.Infrastructure.IoC.Modules
{
    public class RepositoryModule :  Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
    }
}