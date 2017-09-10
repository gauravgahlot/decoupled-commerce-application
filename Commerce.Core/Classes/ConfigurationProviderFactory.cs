using Commerce.Core.Configurations;
using Commerce.Shared.Contracts;
using Commerce.Shared.ExtensionPoints;
using System;
using System.Configuration;

namespace Commerce.Core
{
    public class ConfigurationProviderFactory : IConfigurationProviderFactory
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly ICustomerNotifier _customerNotifier;
        private readonly ICommerceAppEvents _events;

        public ConfigurationProviderFactory(ILogger logger)
        {
            var config = ConfigurationManager.GetSection("commerceApp") as CommerceAppConfigurationSection;
            if (config?.PaymentProcessor.Type != null &&
                config.CustomerNotifier.Type != null)
            {
                _paymentProcessor = Activator.CreateInstance(Type.GetType(config.PaymentProcessor.Type)) as IPaymentProcessor;
                _customerNotifier = Activator.CreateInstance(Type.GetType(config.CustomerNotifier.Type)) as ICustomerNotifier;
                if (_customerNotifier != null)
                {
                    _customerNotifier.FromAddress = config.CustomerNotifier.FromAddress;
                    _customerNotifier.SmtpServer = config.CustomerNotifier.SmtpServer;
                }

                _events = new CommerceAppExtensionPoints();
                foreach (CommerceAppModuleElement element in config.Modules)
                {
                    ICommerceModule module = Activator.CreateInstance(Type.GetType(element.Type)) as ICommerceModule;
                    module.Initialize(_events);
                }
            }
            else
            {
                logger.Log("Incorrect configurations in App.config.");
            }
        }

        public ICustomerNotifier GetCustomerNotifier()
        {
            return _customerNotifier;
        }

        public IPaymentProcessor GetPaymentProcessor()
        {
            return _paymentProcessor;
        }

        public ICommerceAppEvents GetEvents()
        {
            return _events;
        }
    }
}
