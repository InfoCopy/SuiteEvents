using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

using NEventStore.Persistence;
using NEventStore.Persistence.SqlPersistence;

namespace SuiteEvents.Domain.Infrastructures.Concretes
{
    public class ConnectionFactory : IConnectionFactory
    {
        private static readonly IDictionary<string, DbProviderFactory> CachedFactories =
            new Dictionary<string, DbProviderFactory>();

        private readonly string _connectionString;
        private readonly string _providerName;

        private readonly string _replicaConnectionString;
        private readonly string _replicaProviderName;

        public ConnectionFactory(string connectionString, string providerName)
            : this(connectionString, providerName, connectionString, providerName)
        {

        }

        public ConnectionFactory(
            string connectionString,
            string providerName,
            string replicaConnectionString,
            string replicaProviderName)
        {
            this._connectionString = connectionString;
            this._providerName = providerName;
            this._replicaConnectionString = replicaConnectionString;
            this._replicaProviderName = replicaProviderName;
        }

        public IDbConnection OpenMaster(Guid streamId)
        {
            return this.Open(streamId, this._connectionString, this._providerName);
        }

        public virtual IDbConnection OpenReplica(Guid streamId)
        {
            return this.Open(streamId, this._replicaConnectionString, this._replicaProviderName);
        }

        protected virtual IDbConnection Open(Guid streamId, string connectionString, string providerName)
        {
            return new ConnectionScope(connectionString, () => this.Open(connectionString, providerName));
        }

        protected virtual IDbConnection Open(string connectionString, string providerName)
        {
            var factory = this.GetFactory(providerName);
            var connection = factory.CreateConnection();
            if (connection == null)
                throw new ConfigurationErrorsException("Invalid provider name");

            connection.ConnectionString = connectionString;

            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                throw new StorageUnavailableException(e.Message, e);
            }

            return connection;
        }

        protected virtual DbProviderFactory GetFactory(string providerName)
        {
            lock (CachedFactories)
            {
                DbProviderFactory factory;
                if (CachedFactories.TryGetValue(providerName, out factory))
                    return factory;

                factory = DbProviderFactories.GetFactory(providerName);
                return CachedFactories[providerName] = factory;
            }
        }

        public ConnectionStringSettings Settings
        {
            get { return new ConnectionStringSettings("EventStore", this._connectionString, this._providerName); }
        }
    }
}
