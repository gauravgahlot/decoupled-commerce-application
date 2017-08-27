using Commerce.Shared.Models;

namespace Commerce.Core
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(PaymentDetails payment);
    }
}
