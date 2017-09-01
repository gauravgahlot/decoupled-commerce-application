using Commerce.Shared.Models;

namespace Commerce.Shared.Contracts
{
    public interface ICustomerValidator
    {
        bool ValidateCustomer(Customer customer);
    }
}
