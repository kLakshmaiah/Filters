using Filters.Filters.ServiceFilter.Action;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceFilterController : ControllerBase
    {
        [ServiceFilter(typeof(DeviceActionIsNotWorkingServiceFilter))]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
