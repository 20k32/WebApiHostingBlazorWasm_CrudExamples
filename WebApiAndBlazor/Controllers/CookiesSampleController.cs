using Microsoft.AspNetCore.Mvc;
using Models;

namespace AspHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CookiesSample : ControllerBase
    {
        private const string COOKIE_KEY = "DataTransferCookie";

        [HttpPost("PostData")]
        public IActionResult PostData([FromBody] PostModel Model)
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddSeconds(10);

            Response.Cookies.Append(COOKIE_KEY, $"[from cookies] {Model.Data}", cookieOptions);

            return Ok();
        }

        [HttpGet("GetData")]
        public string GetData()
        {
            Request.Cookies.TryGetValue(COOKIE_KEY, out var result);

            return result ?? string.Empty;
        }
    }
}
