using Microsoft.AspNetCore.Mvc;
using StockScanner.Api.Services.Interfaces;
using StockScanner.Api.Strategies;

namespace StockScanner.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GapReversalStrategyController : ControllerBase
    {

        private readonly IInteractiveBrokersService _interactiveBrokersService;
        private readonly GapReversalStrategy _gapReversalStrategy;

        public GapReversalStrategyController(
             IInteractiveBrokersService interactiveBrokersService,
             GapReversalStrategy gapReversalStrategy)
        {
            _interactiveBrokersService = interactiveBrokersService;
            _gapReversalStrategy = gapReversalStrategy;
        }

        [HttpGet("run")]
        public async Task<IActionResult> Run(CancellationToken cancellationToken)
        {
            Console.WriteLine("GAP: Run STARTED");

            var connected = await _interactiveBrokersService.ConnectAsync(cancellationToken);

            if (!connected)
            {
                return StatusCode(503, new
                {
                    strategy = "GapReversal",
                    connected = false,
                    scannerStarted = false,
                    message = "Interactive Brokers is not available"
                });
            }


            Console.WriteLine("GAP: ConnectAsync finished");


            await _gapReversalStrategy.StartScannerAsync();

            return Ok(
                new
                {
                    strategy = "GapReversal",
                    connected = true
                });
        }
    }
}
