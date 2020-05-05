using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Moq;
using TravelHelper.Infrastructure.Services;
using TravelHelper.Core.Repositories;
using AutoMapper;
using TravelHelper.Core.Domain;

namespace TravelHelper.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock= new Mock<IEncrypter>();
            var userService = new UserService(userRepositoryMock.Object,encrypterMock.Object,mapperMock.Object);
            await userService.RegisterAsync("user@email.com","user","secret");
            userRepositoryMock.Verify(x=>x.AddAsync(It.IsAny<User>()),Times.Once);

        }
    }
}