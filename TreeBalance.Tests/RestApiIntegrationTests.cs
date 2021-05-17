using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using TreeBalance.API;
using TreeBalance.Shared;
using Xunit;

namespace TreeBalance.Tests {
    public class RestApiIntegrationTests {

        private readonly HttpClient _client;

        public RestApiIntegrationTests() {
            _client = new TestServer(new WebHostBuilder().UseEnvironment("Development").UseStartup<Startup>())
                    .CreateClient();
        }

        [Theory]
        [InlineData("1-2-3-4-5-6-7")]
        public async Task TestApiGetMethod(string requestTree) {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/tree/" + requestTree);
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var node = NodeSerializer.Deserialize(data);
            Assert.True(BalanceExample.IsAvl(node));
        }
    }
}