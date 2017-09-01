using Commerce.Core.Configurations;
using Commerce.Shared.Contracts;
using System;
using System.Configuration;

namespace Commerce.Core
{
    public class ConfigurationProviderFactory : IConfigurationProviderFactory
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly ICustomerNotifier _customerNotifier;

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
    }
}
