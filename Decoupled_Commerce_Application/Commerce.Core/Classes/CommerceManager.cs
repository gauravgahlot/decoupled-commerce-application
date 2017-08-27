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

        public CommerceManager(IStoreRepository storeRepository,
            ICustomerValidator customerValidator,
            IPaymentProcessor paymentProcessor,
            ICustomerNotifier customerNotifier, ILogger logger)
        {
            _storeRepository = storeRepository;
            _customerValidator = customerValidator;
            _paymentProcessor = paymentProcessor;
            _customerNotifier = customerNotifier;
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
