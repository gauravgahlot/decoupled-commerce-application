using Commerce.Shared.Models;
using Commerce.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Core
{
    public class CommerceManager
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly ICustomerNotifier _customerNotifier;
        private readonly ILogger _logger;

        public CommerceManager(IStoreRepository storeRepository,
            IPaymentProcessor paymentProcessor,
            ICustomerNotifier customerNotifier, ILogger logger)
        {
            _storeRepository = storeRepository;
            _paymentProcessor = paymentProcessor;
            _customerNotifier = customerNotifier;
            _logger = logger;
        }

        public bool ProcessOrder(Order order)
        {
            
            return true;
        }
    }
}
