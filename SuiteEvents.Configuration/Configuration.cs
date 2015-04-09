using System;
using System.Configuration;

namespace SuiteEvents.Configuration
{
    public static class Configuration
    {
        private static string _suiteEventsEventStoreConnection;
        public static string SuiteEventsEventStoreConnection
        {
            get
            {
                if (String.IsNullOrEmpty(_suiteEventsEventStoreConnection))
                    _suiteEventsEventStoreConnection = ConfigurationManager.ConnectionStrings["EventStore"].ConnectionString;

                return _suiteEventsEventStoreConnection;
            }
        }

        private static string _suiteEventsReadModelConnection;
        public static string SuiteEventsReadModelConnection
        {
            get
            {
                if (String.IsNullOrEmpty(_suiteEventsReadModelConnection))
                    _suiteEventsReadModelConnection = ConfigurationManager.ConnectionStrings["ReadModel"].ConnectionString;

                return _suiteEventsReadModelConnection;
            }
        }

        private static SuiteEventsSectionHandler _suiteEventsSection;
        public static SuiteEventsSectionHandler SuiteEventsSection
        {
            get
            {
                return _suiteEventsSection ??
                       (_suiteEventsSection =
                           ConfigurationManager.GetSection("SuiteEvents/ApplicationInfo/ApplicationConfig") as
                               SuiteEventsSectionHandler);
            }
        }
    }
}
