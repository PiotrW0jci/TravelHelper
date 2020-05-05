using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using TravelHelper.Api;
using TravelHelper.Infrastructure.DTO;
using Xunit;
using FluentAssertions;

namespace TravelHelper.Tests.EndToEnd.Controllers
{
    public class UserControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public UserControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                            .UseStartup<Startup>());
           _client = _server.CreateClient();
        }
        [Fact]
         public async Task given_valid_email_user_should_exist()
        {
            // Act
            var email = "user1@email.com";
            var response = await _client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();
            
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);
            // Assert
            user.Email.Should().BeEquivalentTo(email);
        }
    }
}