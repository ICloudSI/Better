using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

using Infrastructure.IoC.Modules;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.IoC
{
    public class ContainerModule : Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<AutoMapperModule>();
        }
    }
}
