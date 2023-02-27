using System.Linq.Expressions;

namespace WebProject.Domain.Common;

public abstract class Specification<TEntity>
{
    public abstract Expression<Func<TEntity, bool>> ToExpression();

    public bool IsSatisfiedBy(TEntity entity)
    {
        Func<TEntity, bool> predicate = ToExpression().Compile();
        return predicate(entity);
    }
}
