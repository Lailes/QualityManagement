using TreeBalance.Shared;
using Xunit;
using static TreeBalance.Shared.BalanceExample;

namespace TreeBalance.Tests {
    public class WhiteBoxTests {
        [Fact]
        public void TestBalanceFactorTwo() {
            var node = new Node(5);
            node = Insert(node, 2);
            node = Insert(node, 10);
            node = Insert(node, 8);
            node = Insert(node, 11);
            node = Insert(node, 7);
            node = Insert(node, 6);
            
            node = Balance(node);

            Assert.True(IsAvl(node));
        }


        [Fact]
        public void TestBalanceFactorMinusTwo() {
            var node = new Node(10);
            node = Insert(node, 5);
            node = Insert(node, 11);
            node = Insert(node, 1);
            node = Insert(node, 6);
            node = Insert(node, 7);
            node = Insert(node, 8);
            node = Insert(node, 9);

            node = Balance(node);
            
            Assert.True(IsAvl(node));
        }
    }
}