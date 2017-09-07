using System.Configuration;

namespace Commerce.Core.Configurations
{
    public class CommerceAppConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("paymentProcessor", IsRequired = true)]
        public PaymentProcessorElement PaymentProcessor
        {
            get { return (PaymentProcessorElement)base["paymentProcessor"]; }
            set { base["paymentProcessor"] = value; }
        }

        [ConfigurationProperty("customerNotifier", IsRequired = true)]
        public CustomerNotifierElement CustomerNotifier
        {
            get { return (CustomerNotifierElement)base["customerNotifier"]; }
            set { base["customerNotifier"] = value; }
        }

        [ConfigurationProperty("modules", IsRequired = true)]
        public CommerceAppModules Modules
        {
            get { return (CommerceAppModules)base["modules"]; }
            set { base["modules"] = value; }
        }
    }
}
