using WebProject.Domain.Common;

namespace WebProject.Domain.UserAggregate;

public class User : Entity, IAggregateRoot
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public User(Guid id, string name, string email, string password) : base(id) =>
        (Name, Email, Password) = (name, email, password);
}
