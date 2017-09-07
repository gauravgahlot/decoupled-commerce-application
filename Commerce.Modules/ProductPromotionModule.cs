using Commerce.Shared.Contracts;
using Commerce.Shared.ExtensionPoints;

namespace Commerce.Modules
{
    public class ProductPromotionModule : ICommerceModule
    {
        public void Initialize(CommerceAppExtensionPoints extensions)
        {
            extensions.OrderItemProcessed += OnOrderItemProcessed;
        }

        private void OnOrderItemProcessed(OrderItemProcessedEventArgs args)
        {
            if(args.LineItem.Id == 2)
            {
                args.LineItem.UnitPrice -= 20;
            }
        }
    }
}
