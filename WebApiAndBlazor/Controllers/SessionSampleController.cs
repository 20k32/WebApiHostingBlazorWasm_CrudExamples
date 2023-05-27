using Microsoft.AspNetCore.Mvc;
using Models;

namespace AspHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionSample : ControllerBase
    {
        private const string SESSION_KEY = "DataTransferSession";

        [HttpGet("GetData")]
        public string GetData()
        {
            string result = HttpContext.Session.GetString(SESSION_KEY)!;

            return result ?? string.Empty;
        }

        [HttpPost("PostData")]
        public IActionResult PostData([FromBody] PostModel Model)
        {
            var resultString = $"[from session] {Model.Data}";
            HttpContext.Session.SetString(SESSION_KEY, resultString);

            return Ok();
        }
    }
}
