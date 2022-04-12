using System.Linq.Expressions;

namespace InventoryManagment.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
        IReadOnlyList<T> GetAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Exist(int id);
        bool Any(Func<T, bool> predicate);
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity);
        Task DeleteAsync (T entity);
        Task<bool> ExistAsync(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    }
}
