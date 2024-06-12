using Filters.Filters;
using Filters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        [TypeFilter(typeof(DevicePostActionFIlter))]
        [HttpPost]
        public IActionResult Post(string name)
        {
            if(ModelState.IsValid)
            {

                return Ok("this is is Laxman");
            }
            return Ok(name);
        }
        [HttpGet]
        [TypeFilter(typeof(DeviceActionIsNotWorking))]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
