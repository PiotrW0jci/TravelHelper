using System.Runtime.CompilerServices;
using Autofac;
using Microsoft.Extensions.Configuration;
using TravelHelper.Infrastructure.IoC.Modules;
using TravelHelper.Infrastructure.Mappers;

namespace TravelHelper.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            
        }          
    }
}