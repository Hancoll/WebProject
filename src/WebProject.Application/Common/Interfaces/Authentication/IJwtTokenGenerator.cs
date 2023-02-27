using WebProject.Domain.UserAggregate;

namespace WebProject.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
