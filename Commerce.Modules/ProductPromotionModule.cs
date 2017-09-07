using System;
using Commerce.Shared.Contracts;
using Commerce.Shared.ExtensionPoints;

namespace Commerce.Modules
{
    public class ProductPromotionModule : ICommerceModule
    {
        public void Initialize(ICommerceAppEvents extensions)
        {
            extensions.OrderItemProcessed += OnOrderItemProcessed;
        }

        private void OnOrderItemProcessed(OrderItemProcessedEventArgs args)
        {
            if(args.LineItem.Id == 102)
            {
                args.LineItem.UnitPrice -= 20;
            }
        }
    }
}
