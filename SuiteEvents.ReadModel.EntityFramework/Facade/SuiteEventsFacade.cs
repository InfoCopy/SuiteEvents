using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using SuiteEvents.Persistence.Mapings;

namespace SuiteEvents.Persistence.Facade
{
    public class SuiteEventsFacade : DbContext
    {
        static SuiteEventsFacade()
        {
            Database.SetInitializer<SuiteEventsFacade>(null);
        }

        public SuiteEventsFacade()
            : base("Name=ReadModel")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SuiteEventsFacade>());
        }

        public DbSet<SuiteUsers> SuiteUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new SuiteUsersMap());
        }
    }
}
