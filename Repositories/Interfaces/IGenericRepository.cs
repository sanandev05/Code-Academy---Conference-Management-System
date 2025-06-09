using System.Linq.Expressions;
using Code_Academy___Conference_Management_System.Entities;

namespace Code_Academy___Conference_Management_System.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity,new()
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(int id);
    }

}
