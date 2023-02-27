using WebProject.Domain.Common;

namespace WebProject.Application.Common.Interfaces.Persistence;

public interface IRepository<TEntity> where TEntity : class, IAggregateRoot
{
    TEntity? GetEntity(Specification<TEntity> specification);

    IEnumerable<TEntity> GetEntities(Specification<TEntity> specification);

    Task AddAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task SaveAsync();
}
