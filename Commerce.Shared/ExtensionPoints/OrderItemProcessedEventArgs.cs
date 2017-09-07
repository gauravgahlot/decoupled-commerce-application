using Commerce.Shared.Models;
using System.ComponentModel;

namespace Commerce.Shared.ExtensionPoints
{
    public class OrderItemProcessedEventArgs : CancelEventArgs
    {
        public Product LineItem { get; set; }
    }
}
