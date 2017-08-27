using Autofac;
using Commerce.Core;
using Commerce.Shared.Repositories;
using System.Linq;

namespace Commerce.Client
{
    class Program
    {
        static void Main()
        {
            // setup
            IContainer container = IoCBuilder.Build();

            // consuming the commerce core
            using (var scope = container.BeginLifetimeScope())
            {
                var order = scope.Resolve<IOrderRepository>().Orders().First();
                var commerceManager = scope.Resolve<CommerceManager>();
                commerceManager.ProcessOrder(order);
            }

            System.Console.ReadKey();
        }
    }
}
