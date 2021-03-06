﻿using Autofac;
using Commerce.Core;
using Commerce.Shared.Contracts;
using Commerce.Shared.Repositories;

namespace Commerce.Client
{
    internal static class IoCBuilder
    {
        internal static IContainer Build()
        {
            var builder =  new ContainerBuilder();

            builder.RegisterType<CommerceManager>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<StoreRepository>().As<IStoreRepository>();
            builder.RegisterType<ConfigurationProviderFactory>().As<IConfigurationProviderFactory>();
            builder.RegisterType<CustomerValidator>().As<ICustomerValidator>();
            builder.RegisterType<Logger>().As<ILogger>();

            return builder.Build();
        }
    }
}
