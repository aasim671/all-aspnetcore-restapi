using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class longWalkingStreetController : ControllerBase
    {

        [HttpGet("GetAllData")]
        public IActionResult GetAllData()
        {

          string[]  data = new string[] {"'kdfjd'", "'asim'", "'ahad'"} ; 
            return Ok(data);
        }
    }
}
