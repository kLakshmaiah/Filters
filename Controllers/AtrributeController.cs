using Filters.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtrributeController : ControllerBase
    {
        [HttpGet]
        //[DeviceActionIsNotWorking(1)]
        [AttributeIFilterFactory(10,"Laxman")]
        public IActionResult GetAction()
        {
            return Ok();
        }
    }
}
