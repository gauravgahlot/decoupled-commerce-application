using Commerce.Core.Configurations;
using Commerce.Shared.Contracts;
using Commerce.Shared.Models;
using Commerce.Shared.Repositories;
using System;
using System.Configuration;

namespace Commerce.Core
{
    public class CommerceManager
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ICustomerValidator _customerValidator;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly ICustomerNotifier _customerNotifier;
        private readonly ILogger _logger;

        public CommerceManager(IStoreRepository storeRepository,
            ICustomerValidator customerValidator,
            ILogger logger)
        {
            _storeRepository = storeRepository;
            _customerValidator = customerValidator;
            var config = ConfigurationManager.GetSection("commerceApp") 
                as CommerceAppConfigurationSection;
            if (config != null)
            {
                _paymentProcessor = Activator.CreateInstance(Type.GetType(config.PaymentProcessor.Type)) as IPaymentProcessor;
                _customerNotifier = Activator.CreateInstance(Type.GetType(config.CustomerNotifier.Type)) as ICustomerNotifier;
                _customerNotifier.FromAddress = config.CustomerNotifier.FromAddress;
                _customerNotifier.SmtpServer = config.CustomerNotifier.SmtpServer;
            }
            _logger = logger;
        }

        public bool ProcessOrder(Order order)
        {
            var result = false;
            if (_customerValidator.ValidateCustomer(order.Customer))
            {
                foreach(var lineItem in order.LineItems)
                {
                    // updating store inventory
                    _storeRepository.UpdateInventoryForProduct(lineItem.Id, lineItem.Quantity);

                    // processing the order payment
                    result = _paymentProcessor.ProcessPayment(order.PaymentDetails);


                    // notifying the customer for order status
                    _customerNotifier.NotifyCustomer(result);
                }
            }
            return result;
        }
    }
}
