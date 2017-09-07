using Commerce.Shared.Contracts;
using Commerce.Shared.ExtensionPoints;
using Commerce.Shared.Models;
using Commerce.Shared.Repositories;

namespace Commerce.Core
{
    public class CommerceManager
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ICustomerValidator _customerValidator;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly ICustomerNotifier _customerNotifier;
        private readonly ILogger _logger;
        private readonly ICommerceAppEvents _events;

        public CommerceManager(IStoreRepository storeRepository,
            IConfigurationProviderFactory configFactory,
            ICustomerValidator customerValidator,
            ILogger logger)
        {
            _storeRepository = storeRepository;
            _paymentProcessor = configFactory.GetPaymentProcessor();
            _customerNotifier = configFactory.GetCustomerNotifier();
            _events = configFactory.GetEvents();
            _customerValidator = customerValidator;
            _logger = logger;
        }

        public bool ProcessOrder(Order order)
        {
            var paymentStatus = false;
            if (_customerValidator.ValidateCustomer(order.Customer))
            {
                foreach(var lineItem in order.LineItems)
                {
                    // raise event to check for product promotions
                    if(_events.OrderItemProcessed != null)
                    {
                        var args = new OrderItemProcessedEventArgs { LineItem = lineItem };
                        _events.OrderItemProcessed(args);

                        if (args.Cancel)
                        {
                            return paymentStatus;
                        }
                    }

                    // updating store inventory
                    _storeRepository.UpdateInventoryForProduct(lineItem.Id, lineItem.Quantity);

                    // processing the order payment
                    paymentStatus = _paymentProcessor.ProcessPayment(order.PaymentDetails);
                }

                // log if order processing fails
                if(!paymentStatus)
                    _logger.Log($"Order with Order_Id: {order.Id} could not be placed.");

                // notifying the customer for order status
                _customerNotifier.NotifyCustomer(paymentStatus);
            }
            return paymentStatus;
        }
    }
}
