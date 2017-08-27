namespace Commerce.Shared.Repositories
{
    public interface IStoreRepository
    {
        void UpdateInventoryForProduct(int productId, int quanitySold);
    }
}
