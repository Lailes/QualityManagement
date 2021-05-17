using TreeBalance.Shared;
using Xunit;
using static TreeBalance.Shared.BalanceExample;

namespace TreeBalance.Tests {
    public class BlackBoxTests {

        [Fact]
        public void TestForward() {
            var node = new Node(0);
            for (var i = 1; i < 10; i++) {
                node = Insert(node, i);
            }

            node = Balance(node);

            Assert.True(IsAvl(node));
        }

        [Fact]
        public void TestBackward() {
            var node = new Node(21);
            for (var i = 20; i >= 0; i--) {
                node = Insert(node, i);
            }
            
            node = Balance(node);

            Assert.True(IsAvl(node));
        }
    }
}