using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using SuiteEvents.ReadModel.Dtos;

namespace SuiteEvents.ReadModel.Services.Abstracts
{
    public interface IReadRepository<TEntity> where TEntity : DtoBase
    {
        TEntity GetEntityById(Guid id);
        IList<TEntity> GetAll(int pageIndex, int pageSize, out int totalItems);
        IList<TEntity> QueryAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
    }
}
