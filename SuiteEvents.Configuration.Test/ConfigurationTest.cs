using NUnit.Framework;

namespace SuiteEvents.Configuration.Test
{
    [TestFixture]
    public class ConfigurationTest
    {
        [Test]
        public void ConfigurationGetReadModelConnectionString()
        {
            Assert.AreEqual("Data Source=.\\SqlExpress;Initial Catalog=SuiteEvents;Integrated Security=SSPI;", Configuration.SuiteEventsReadModelConnection);
        }

        [Test]
        public void ConfigurationGetApplicationName()
        {
            Assert.AreEqual("SuiteEvents", Configuration.SuiteEventsSection.SuiteEventsApplicationName);
        }
    }
}
