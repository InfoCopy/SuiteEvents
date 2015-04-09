using System.Configuration;

namespace SuiteEvents.Configuration
{
    public class SuiteEventsSectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("applicationName", IsRequired = true)]
        public string SuiteEventsApplicationName
        {
            get { return (string)this["applicationName"]; }
            set { this["applicationName"] = value; }
        }
    }
}
