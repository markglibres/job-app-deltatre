using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeltaTre.Search.Domain.Seedwork
{
    public interface IRepository<T>
        where T : Entity
    {
        Task InsertAsync(T entity);
        Task SaveAsync(T entity);
        Task<T> GetByAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAll();
    }
}