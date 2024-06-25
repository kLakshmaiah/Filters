using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionMiddleWareController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAction()
        {
            throw new NotImplementedException();
        }
    }
}
