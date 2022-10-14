namespace FormExDi.Application.Repository;

/// <summary>
/// Base repository
/// </summary>
/// <typeparam name="TId">Id type</typeparam>
/// <typeparam name="TEntity">Entity</typeparam>
/// <typeparam name="TModel">Model</typeparam>
public interface IRepository<TId, TEntity, TModel>
    where TEntity : class
    where TModel : class
{
    Task<TModel> AddAsync(TEntity entity);
    Task<TModel> UpdateAsync(TId id, TEntity entity);
    Task<TModel> DeleteAsync(TId id);
    Task<TModel> GetByIdAsync(TId id);
    Task<IEnumerable<TModel>> GetAllAsync();
}
