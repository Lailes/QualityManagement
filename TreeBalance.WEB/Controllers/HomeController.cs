using Microsoft.AspNetCore.Mvc;
using TreeBalance.WEB.Models;

using static TreeBalance.Shared.BalanceExample;
using static TreeBalance.Shared.NodeSerializer;

namespace TreeBalance.WEB.Controllers {
    public class HomeController : Controller {

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(ParseModel model) {
            if (model.TreeRequest == null ||  !VerifyTreeString(model.TreeRequest)) {
                model.TreeResultJson = "Wrong tree line!";
                return View(model);
            }
            var node = CreateNode(model.TreeRequest);
            model.TreeResultJson = Serialize(model.IsBalance ? Balance(node) : node);
            return View(model);
        }
    }
}