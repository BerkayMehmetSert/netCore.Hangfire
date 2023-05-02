using System.Linq.Expressions;
using netCore.Hangfire.Models.Common;

namespace netCore.Hangfire.Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll(Expression<Func<T, bool>>? expression = null);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
