using Commerce.Shared.Models;

namespace Commerce.Shared.Contracts
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(PaymentDetails payment);
    }
}
