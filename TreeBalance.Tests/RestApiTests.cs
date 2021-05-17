using Microsoft.AspNetCore.Mvc;
using TreeBalance.API.Controllers;
using TreeBalance.Shared;
using Xunit;

namespace TreeBalance.Tests {
    public class RestApiTests {
        [Theory]
        [InlineData("1-2-3-4-5-6")]
        public async void TestTreeIndex(string request) {
            var controller = new TreeController();
            var result = (await controller.Get(request)).Value;
            Assert.True(BalanceExample.IsAvl(result));
        }
    }
}