using System;

namespace Commerce.Core
{
    public class EmailNotifier : ICustomerNotifier
    {
        public void NotifyCustomer(bool paymentSuccessful)
        {
            if (paymentSuccessful)
                SendPaymentSuccess();
            else
                SendPaymentFailed();
        }

        private void SendPaymentFailed()
        {
            Console.WriteLine("Notify Customer: Payment failed, order could not be placed.");
        }

        private void SendPaymentSuccess()
        {
            Console.WriteLine("Notify Customer: Payment successfull, order has been placed.");
        }
    }
}
