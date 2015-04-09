using System;
using System.Collections.Generic;

using SuiteEvents.ReadModel.Dtos;
using SuiteEvents.ReadModel.Services.Abstracts;

namespace SuiteEvents.ReadModel.Services.Concretes
{
    public class SuiteUsersRepository : ReadRepository<SuiteUsers>, ISuiteUsersRepository
    {
        private readonly Func<ISuiteUsersPersistor> _suiteUsersPersistor;

        public SuiteUsersRepository(Func<ISuiteUsersPersistor> suiteUsersPersistor)
            :base(suiteUsersPersistor)
        {
            this._suiteUsersPersistor = suiteUsersPersistor;
        }

        public SuiteUsers GetUserByUserName(string userName, string applicationName)
        {
            return this._suiteUsersPersistor().GetUserByUserName(userName, applicationName);
        }

        public SuiteUsers GetUserById(Guid userId, string applicationName)
        {
            return this._suiteUsersPersistor().GetUserById(userId, applicationName);
        }

        public IList<SuiteUsers> GetUsers(int pageIndex, int pageSize, string applicationName, out int totalItems)
        {
            return this._suiteUsersPersistor().GetUsers(pageIndex, pageSize, applicationName, out totalItems);
        }
    }
}
