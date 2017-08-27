using Commerce.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Commerce.Shared.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private List<Product> _products;

        public StoreRepository()
        {
            InitializeInventory();
        }

        public void UpdateInventoryForProduct(int productId, int quanitySold)
        {
            System.Console.WriteLine("Updating inventory...");
            _products.First(p => p.Id == productId).Quantity -= quanitySold;
        }

        private void InitializeInventory()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Id = 101,
                    Name = "iPhone",
                    Quantity = 10,
                    UnitPrice = 200
                },
                new Product
                {
                    Id = 102,
                    Name = "iPad",
                    Quantity = 15,
                    UnitPrice = 800
                },
                new Product
                {
                    Id = 103,
                    Name = "MacBook Pro",
                    Quantity = 20,
                    UnitPrice = 2000
                },
                new Product
                {
                    Id = 104,
                    Name = "Dell XPS",
                    Quantity = 25,
                    UnitPrice = 1800
                }
            };
        }
    }
}
