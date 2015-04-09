using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using SuiteEvents.ReadModel.Dtos;
using SuiteEvents.ReadModel.Services.Abstracts;

namespace SuiteEvents.ReadModel.Services.Concretes
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity:DtoBase
    {
        protected readonly Func<IPersistor> Persistor;

        public ReadRepository(Func<IPersistor> persistor)
        {
            this.Persistor = persistor;
        }

        public TEntity GetEntityById(Guid id)
        {
            return this.Persistor().GetEntityById<TEntity>(id);
        }

        public IList<TEntity> GetAll(int pageIndex, int pageSize, out int totalItems)
        {
            var entityList = this.Persistor().GetAll<TEntity>(pageIndex, pageSize);
            totalItems = entityList.Count;

            return entityList;
        }

        public IList<TEntity> QueryAll(Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
            string includeProperties = "")
        {
            throw new NotImplementedException();
        }
    }
}