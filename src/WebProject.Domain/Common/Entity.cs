namespace WebProject.Domain.Common;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Entity entity && Id.Equals(entity.Id);
    }

    public static bool operator ==(Entity left, Entity right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(Entity? other)
    {
        return Equals((object?)other);
    }

    protected Entity(Guid id)
    {
        Id = id;
    }
}
