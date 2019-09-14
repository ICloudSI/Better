using Autofac;
using Better.Infrastructure.IoC.Modules;
using Better.Infrastructure.Mappers;
using Microsoft.Extensions.Configuration;

namespace Better.Infrastructure.IoC
{
    public class ContainerModule :Autofac.Module
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
//            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
//            builder.RegisterModule<MongoModule>();
            builder.RegisterModule<SqlModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
        }          
    }
}