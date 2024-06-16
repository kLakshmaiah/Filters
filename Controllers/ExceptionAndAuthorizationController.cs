using Filters.Filters.AuthorizationFIlter;
using Filters.Filters.ExceptionFilter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Filters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(HandleExcepptionFilter))]
    public class ExceptionAndAuthorizationController : ControllerBase
    {
        [HttpGet]
        //[TypeFilter(typeof(HandleExcepptionFilter))]
        public IActionResult Get()
        {
             throw new Exception("Errror is thrown Manually");
        }
        [TypeFilter(typeof (AuthorizeFilter))]
        [HttpPost]
        public IActionResult Post()
        {
            throw new DivideByZeroException();
        }
    }
}
