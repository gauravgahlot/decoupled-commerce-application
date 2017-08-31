using Commerce.Shared.Contracts;
using Commerce.Shared.Models;
using System;

namespace Commerce.Providers
{
    public class CreditCardProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(PaymentDetails payment)
        {
            Console.WriteLine("Processing payment...");
            return true;
        }
    }
}
