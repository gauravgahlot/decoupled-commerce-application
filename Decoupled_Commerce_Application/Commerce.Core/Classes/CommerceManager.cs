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
            _logger = logger;

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
                _logger.Log("Incorrect configurations in App.config.");
            }
        }

        public bool ProcessOrder(Order order)
        {
            var paymentSuccessfull = false;
            if (_customerValidator.ValidateCustomer(order.Customer))
            {
                foreach(var lineItem in order.LineItems)
                {
                    // updating store inventory
                    _storeRepository.UpdateInventoryForProduct(lineItem.Id, lineItem.Quantity);

                    // processing the order payment
                    paymentSuccessfull = _paymentProcessor.ProcessPayment(order.PaymentDetails);
                }

                // log if order processing fails
                if(!paymentSuccessfull)
                    _logger.Log($"Order with Order_Id: {order.Id} could not be placed.");

                // notifying the customer for order status
                _customerNotifier.NotifyCustomer(paymentSuccessfull);
            }
            return paymentSuccessfull;
        }
    }
}
