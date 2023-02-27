using WebProject.Domain.UserAggregate;

namespace WebProject.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);
