using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Infrastructure.Mappers;

namespace Infrastructure.IoC.Modules
{
    public class AutoMapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAutoMapper(typeof(AutoMapperModule).Assembly);
        }
    }
}
