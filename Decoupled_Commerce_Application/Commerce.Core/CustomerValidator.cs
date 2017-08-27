using Commerce.Shared.Models;
using System;

namespace Commerce.Core
{
    public class CustomerValidator : ICustomerValidator
    {
        public bool ValidateCustomer(Customer customer)
        {
            Console.WriteLine("Validating customer...");
            return true;
        }
    }
}
