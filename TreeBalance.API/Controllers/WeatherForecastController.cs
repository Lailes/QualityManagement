using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TreeBalance.Shared;
using static TreeBalance.Shared.BalanceExample;

namespace TreeBalance.API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class TreeController : ControllerBase {

        [HttpGet("{tree}")]
        public async Task<ActionResult<Node>> Get(string tree) =>
            await Task.Run(() => Balance(CreateNode(tree.Replace('-', ' ')))).ConfigureAwait(false);
    }
}