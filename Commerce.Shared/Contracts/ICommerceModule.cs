using Commerce.Shared.ExtensionPoints;

namespace Commerce.Shared.Contracts
{
    public interface ICommerceModule
    {
        void Initialize(ICommerceAppEvents extensions);
    }
}
