namespace Commerce.Shared.Contracts
{
    public interface ICustomerNotifier
    {
        void NotifyCustomer(bool paymentSuccessful);
    }
}
