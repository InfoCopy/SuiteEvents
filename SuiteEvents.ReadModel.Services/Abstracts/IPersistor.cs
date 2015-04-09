using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using SuiteEvents.ReadModel.Dtos;

namespace SuiteEvents.ReadModel.Services.Abstracts
{
    public interface IPersistor
    {
        void Delete<TEntity>(TEntity entityToDelete) where TEntity:DtoBase;
        void Create<TEntity>(TEntity entityToCreate) where TEntity : DtoBase;
        void Update<TEntity>(TEntity entityToUpdate) where TEntity : DtoBase;

        TEntity GetEntityById<TEntity>(Guid id) where TEntity : DtoBase;
        IList<TEntity> GetAll<TEntity>(int pageIndex, int pageSize, string includeProperties = "") where TEntity : DtoBase;
        IList<TEntity> QueryAll<TEntity>(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") where TEntity : DtoBase;
    }
}
