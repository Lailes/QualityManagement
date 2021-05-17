using System;
using Microsoft.AspNetCore.Mvc;
using TreeBalance.Shared;
using Xunit;
using TreeBalance.WEB.Controllers;
using TreeBalance.WEB.Models;

namespace TreeBalance.Tests {
    public class ControllersTestsMvc {

        [Theory]
        [InlineData("1 2 3 4 5 6 7 8")]
        public void TestHomeIndex(string tree) {
            var homeController = new HomeController();
            var parseModel = new ParseModel {TreeRequest = tree};
            var result = homeController.Index(parseModel) as ViewResult;
            parseModel = result?.Model as ParseModel;
            if (parseModel != null) {
                var node = NodeSerializer.Deserialize(parseModel.TreeResultJson);
                node = BalanceExample.Balance(node);
                Assert.True(BalanceExample.IsAvl(node));
            }
            else {
                throw new Exception("Error");
            }
        }
        
    }
}