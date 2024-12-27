using Microsoft.AspNetCore.Mvc;
using StdntCollege.MyLogging;

namespace StdntCollege.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : Controller
    {
        //Loosely coupled
        private readonly ILogger<DemoController> _logger;
        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public ActionResult Index()
        {
            _logger.LogTrace("Log message from Trace method");
            _logger.LogDebug("Log message from Debug method");
            _logger.LogInformation("Log message from Information method");
            _logger.LogWarning("Log message from Warning method");
            _logger.LogError("Log message from Error method");
            _logger.LogCritical("Log message from Critical method");
            
            return Ok();
        }

    }
}
