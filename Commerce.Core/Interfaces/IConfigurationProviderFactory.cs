using Commerce.Shared.Contracts;
using Commerce.Shared.ExtensionPoints;

namespace Commerce.Core
{
    public interface IConfigurationProviderFactory
    {
        IPaymentProcessor GetPaymentProcessor();
        ICustomerNotifier GetCustomerNotifier();
        ICommerceAppEvents GetEvents();
    }
}
