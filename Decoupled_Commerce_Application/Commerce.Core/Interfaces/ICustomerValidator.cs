using Commerce.Shared.Models;

namespace Commerce.Core
{
    public interface ICustomerValidator
    {
        bool ValidateCustomer(Customer customer);
    }
}
