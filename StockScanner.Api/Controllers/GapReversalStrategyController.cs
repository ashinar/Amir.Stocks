using Microsoft.AspNetCore.Mvc;
using StockScanner.Api.Services.Interfaces;

namespace StockScanner.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GapReversalStrategyController : ControllerBase
    {

        private readonly IInteractiveBrokersService _interactiveBrokersService;

        public GapReversalStrategyController(
            IInteractiveBrokersService interactiveBrokersService)
        {
            _interactiveBrokersService = interactiveBrokersService;
        }

        [HttpGet("run")]
        public async Task<IActionResult> Run(CancellationToken cancellationToken)
        {
            Console.WriteLine("GAP: Run STARTED");

            await _interactiveBrokersService.ConnectAsync(cancellationToken);

            Console.WriteLine("GAP: ConnectAsync finished");
            // כאן בהמשך תיכנס Gap Reversal Strategy

            return Ok(
                new
                {
                    strategy = "GapReversal",
                    connected = true
                });
        }
    }
}
