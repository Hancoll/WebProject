using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Linq;
using WebProject.Application.Common.Interfaces.Persistence;
using WebProject.Domain.Common;

namespace WebProject.Infrastructure.Persistence;

internal sealed class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
{
    private readonly ApplicationDbContext context;

    public async Task AddAsync(TEntity entity)
    {
        await context.AddAsync(entity);
    }

    public Task DeleteAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity> GetEntities(Specification<TEntity> specification)
    {
        return context.Set<TEntity>().Where(specification.ToExpression());
    }

    public TEntity? GetEntity(Specification<TEntity> specification)
    {
        return context.Set<TEntity>().Where(specification.ToExpression()).FirstOrDefault();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }

    public Repository(ApplicationDbContext context) => this.context = context; 
}
