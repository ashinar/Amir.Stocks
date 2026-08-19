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
        public async Task<IActionResult> Run(
            CancellationToken cancellationToken)
        {
            await _interactiveBrokersService.ConnectAsync(cancellationToken);

      
            // כאן בהמשך תיכנס Gap Reversal Strategy

            return Ok(new
            {
                strategy = "GapReversal",
                connected = true
            });
        }
    }
}
