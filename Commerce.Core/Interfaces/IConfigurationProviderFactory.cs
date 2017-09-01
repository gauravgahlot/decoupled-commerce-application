using Commerce.Shared.Contracts;

namespace Commerce.Core
{
    public interface IConfigurationProviderFactory
    {
        IPaymentProcessor GetPaymentProcessor();
        ICustomerNotifier GetCustomerNotifier();
    }
}
