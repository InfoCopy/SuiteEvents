using System.Linq;
using SuiteEvents.ReadModel.Dtos;

namespace SuiteEvents.ReadModel.Abstracts
{
    public interface IReadModelDatabase
    {
        IQueryable<SuiteUsers> SuiteUsers { get; } 
    }
}
