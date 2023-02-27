using WebProject.Application.Common.Interfaces.Authentication;
using WebProject.Application.Common.Interfaces.Persistence;
using WebProject.Domain.UserAggregate;
using WebProject.Domain.UserAggregate.Specifications;

namespace WebProject.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IRepository<User> userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IRepository<User> userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }

    public AuthenticationResult Register(string name, string email, string password)
    {
        // 1. Validate the user doesn't exist
        if (userRepository.GetEntity(new UserByEmailSpecification(email)) is not null)
        {
            throw new Exception("User with given email exists.");
        }

        // 2. Create user (generate unique ID) & Persist to DB
        var user = new User(Guid.NewGuid(), name, email, password);

        userRepository.AddAsync(user);
        userRepository.SaveAsync();

        // 3. Create JWT token 
        var token = jwtTokenGenerator.GenerateToken(user);

        return new(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validate the user exists
        if (userRepository.GetEntity(new UserByEmailSpecification(email)) is not User user)
        {
            throw new Exception("User with given email does not exists.");
        }

        // 2. Validate the password is correct
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        // 3. Create JWT token
        var token = jwtTokenGenerator.GenerateToken(user);

        return new(user, token);
    }
}
