using Microsoft.AspNetCore.Mvc;

namespace StockScanner.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GapReversalStrategyController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Message = "Stock Scanner API is running"
            });
        }
    }
}
