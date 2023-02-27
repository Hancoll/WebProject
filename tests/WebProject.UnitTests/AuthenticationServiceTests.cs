using Moq;
using WebProject.Application.Common.Interfaces.Authentication;
using WebProject.Application.Common.Interfaces.Persistence;
using WebProject.Application.Services.Authentication;
using WebProject.Domain.UserAggregate;
using WebProject.Domain.UserAggregate.Specifications;

namespace WebProject.UnitTests;

public class AuthenticationServiceTests
{
    private readonly AuthenticationService sut;
    private readonly Mock<IJwtTokenGenerator> jwtTokenGeneratorMock = new Mock<IJwtTokenGenerator>();
    private readonly Mock<IRepository<User>> userRepositoryMock = new Mock<IRepository<User>>();

    public AuthenticationServiceTests()
    {
        sut = new AuthenticationService(jwtTokenGeneratorMock.Object, userRepositoryMock.Object);
    }

    [Fact]
    public void Login_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var userName = "user12321";
        var userEmail = "xx@yy.com";
        var userPassword = "P@ssw0rd_";

        var user = new User(userId, userName, userEmail, userPassword);

        userRepositoryMock.Setup(x => x.GetEntity(It.IsAny<UserByEmailSpecification>())).Returns(user);

        jwtTokenGeneratorMock.Setup(x => x.GenerateToken(user)).Returns("token");

        // Act
        var authenticationResult = sut.Login(userEmail, userPassword);

        // Assert
        Assert.Equal(authenticationResult.User.Id, userId);
        Assert.Equal(authenticationResult.User.Name, userName);
    }
}
