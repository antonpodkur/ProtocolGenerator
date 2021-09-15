using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers
{
    [Route("")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Success");
        }
    }
}