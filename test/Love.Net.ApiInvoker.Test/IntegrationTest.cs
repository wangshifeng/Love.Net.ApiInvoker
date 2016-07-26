using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Host;
using Xunit;
using Love.Net.Core;

namespace Love.Net.ApiInvoker.Test {
    public class User {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class IntegrationTest {
        private const string _appId = "CEKPXdNm3o7PvtKyQ19uL5";
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly IAppPush _push;

        public IntegrationTest() {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
            _push = _server.Host.Services.GetService<IAppPush>();
        }

        [Theory]
        [InlineData(1)]
        public async Task ReturnValue(int id) {
            // Act
            var response = await _client.GetAsync($"/api/values/{id}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("value", responseString);
        }

        [Fact]
        public async Task Push_Message_To_List_Alias_Test() {
            var result = await _push.PushMessageToListAsync(_appId, 
                "{ \"UserName\": \"rigofunc\"}", Target.FromAlias("rigofunc"));

            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task Push_Message_To_List_ClientId_Test() {
            var result = await _push.PushMessageToListAsync(_appId, 
                "{ \"UserName\": \"rigofunc\"}", new Target { ClientId = "857061aec1f8d9a0bce554e0bb2e63d4" });

            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task Push_Message_To_App_Test() {
            var result = await _push.PushMessageToAppAsync(_appId, "{ \"UserName\": \"rigofunc\"}");

            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task Push_Message_To_List_Invalid_List_Test() {
            var result = await _push.PushMessageToListAsync(_appId, "{ \"UserName\": \"rigofunc\"}", new Target());

            Assert.False(result.Succeeded);
        }

        [Fact]
        public async Task Push_Generic_AppMessage_To_List_Test() {
            var message = new AppMessage<User> {
                Title = "xUnit test",
                Content = new User {
                    UserName = "rigofunc",
                    Password = "P@ssword"
                },
                Kind = "1"
            };

            var result = await _push.PushMessageToListAsync(_appId, message, Target.FromAlias("rigofunc"));

            Assert.True(result.Succeeded);
        }
    }
}
