using Commerce.Shared.Models;

namespace Commerce.Shared.Repositories
{
    public interface IStoreRepository
    {
        void UpdateInventoryForProduct(Product lineItem);
    }
}
