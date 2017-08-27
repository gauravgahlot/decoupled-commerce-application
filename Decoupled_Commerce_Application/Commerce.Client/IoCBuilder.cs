using Autofac;
using Commerce.Core;
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

            return builder.Build();
        }
    }
}
