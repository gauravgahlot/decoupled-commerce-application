using Commerce.Shared.Models;
using System.Collections.Generic;

namespace Commerce.Shared.Repositories
{
    public interface IOrderRepository
    {
        List<Order> Orders();
        Order GetOrderById(int id);
    }
}
