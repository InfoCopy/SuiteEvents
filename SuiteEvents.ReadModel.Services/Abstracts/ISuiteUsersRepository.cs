using System;
using System.Collections.Generic;

using SuiteEvents.ReadModel.Dtos;

namespace SuiteEvents.ReadModel.Services.Abstracts
{
    public interface ISuiteUsersRepository : IReadRepository<SuiteUsers>
    {
        SuiteUsers GetUserByUserName(string userName, string applicationName);
        SuiteUsers GetUserById(Guid userId, string applicationName);
        IList<SuiteUsers> GetUsers(int pageIndex, int pageSize, string applicationName, out int totalItems);
    }
}
