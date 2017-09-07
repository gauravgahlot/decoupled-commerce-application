namespace Commerce.Shared.ExtensionPoints
{
    public delegate void CommereAppExtension<T>(T args);

    public interface ICommerceAppEvents
    {
        CommereAppExtension<OrderItemProcessedEventArgs> OrderItemProcessed { get; set; }
    }

    public class CommerceAppExtensionPoints : ICommerceAppEvents
    {
        public CommereAppExtension<OrderItemProcessedEventArgs> OrderItemProcessed { get; set; }
    }
}
