using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using SuiteEvents.Domain.Services.Dtos;

namespace SuiteEvents.Domain.Services.Abstracts
{
    public interface ISuiteEventsService<T> where T: DtoBase
    {
        T Create(Guid id);
        Task InsertAsync(T entityToAdd);
        Task UpdateAsync(T entityToUpdate);
        void Delete(Guid id);

        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllAsync(int pageIndex, int pageSize, string includeProperties = "");
        Task<IReadOnlyCollection<T>> QueryAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
    }
}
