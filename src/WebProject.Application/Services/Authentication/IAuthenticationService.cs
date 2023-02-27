using System.Runtime.CompilerServices;

namespace WebProject.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Login(string email, string password);

    AuthenticationResult Register(string name, string email, string password);
}
