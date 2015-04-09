using System;
using System.Data.Entity.ModelConfiguration;
using SuiteEvents.ReadModel.Dtos;

namespace SuiteEvents.ReadModel.EntityFramework.Mappings
{
    public abstract class BaseMapping<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : DtoBase
    {
        protected BaseMapping(String tableName)
        {
            #region Key
            HasKey(t => t.Id);
            #endregion

            #region Table
            ToTable(tableName);
            #endregion
        }
    }
}
