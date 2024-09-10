using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(ILogger<ServiceController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Service")]
        public string Get()
        {
            _logger.LogInformation("Log form Service B!!!!");
            return "Hello! from Service B.......";
        }
    }
}
