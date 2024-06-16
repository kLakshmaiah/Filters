using Filters.Filters.Action;
using Filters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[TypeFilter(typeof(DevicePostActionFIlter), Arguments = new Object[] { 1 })]
    [TypeFilter(typeof(DevicePostActionFIlter),Arguments =new Object[] {3},Order =3)]
    public class DeviceController : ControllerBase
    {
        //[TypeFilter(typeof(DevicePostActionFIlter), Arguments = new Object[] { 2 })]
        [TypeFilter(typeof(DevicePostActionFIlter), Arguments = new Object[] { 2 }, Order = 2)]
        [HttpPost]
        public IActionResult Post([FromBody]AssignmentPerCourse user)
        {

                return Ok(user);
        }
         // [HttpGet]
        //[TypeFilter(typeof(DeviceActionIsNotWorking), Arguments = new Object[] { 3 })]
        //[TypeFilter(typeof(DeviceActionIsNotWorking), Arguments = new Object[] { 1 },Order =1)]
        //public IActionResult Get()
        //{
        //    return Ok();
        //}
        [HttpGet]
        //public IActionResult Get([FromRoute]int id)
        //{
        //    return Ok(id);
        //}
        //public IActionResult Get([FromHeader] int id)
        //{
        //    return Ok(id);
        //}
        public IActionResult Get([FromQuery] int id)
        {
            return Ok(id);
        }

    }
}
