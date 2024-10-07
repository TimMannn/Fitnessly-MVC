using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = new List<string> { "Item1", "Item2" };
            return Ok(data);
        }
    }
}
