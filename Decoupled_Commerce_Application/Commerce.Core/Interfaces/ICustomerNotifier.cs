namespace Commerce.Core
{
    public interface ICustomerNotifier
    {
        void NotifyCustomer(bool paymentSuccessful);
    }
}
