using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

using SuiteEvents.ReadModel.Abstracts;
using SuiteEvents.ReadModel.Dtos;
using SuiteEvents.ReadModel.EntityFramework.Mappings;

namespace SuiteEvents.ReadModel.EntityFramework.Facade
{
    public class ReadModelDatabase : DbContext, IReadModelDatabase
    {
        private readonly DbSet<SuiteUsers> _suiteUsers;

        public ReadModelDatabase() :
            base("ReadModel")
        {
            this._suiteUsers = base.Set<SuiteUsers>();
        }

        public IQueryable<SuiteUsers> SuiteUsers
        {
            get { return this._suiteUsers; }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.Configurations.Add(new SuiteUsersMap());
        }
    }
}
