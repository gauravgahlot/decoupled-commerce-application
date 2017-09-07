using System.Configuration;
using System.Linq;

namespace Commerce.Core.Configurations
{
    [ConfigurationCollection(typeof(CommerceAppModuleElement))]
    public class CommerceAppModules : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CommerceAppModuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CommerceAppModuleElement)element).Name;
        }

        public CommerceAppModuleElement GetElementByType(string type)
        {
            return this.Cast<CommerceAppModuleElement>().FirstOrDefault(m => m.Type == type);
        }
    }
}
