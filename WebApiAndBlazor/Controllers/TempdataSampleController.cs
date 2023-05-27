using Microsoft.AspNetCore.Mvc;
using Models;
using System.Reflection.Metadata.Ecma335;

namespace AspHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TempdataSample : Controller
    {
        private const string TEMPDATA_KEY = "DataTransferTemp";

        [HttpGet("GetData")]
        public string GetData()
        {
            string result = (string)TempData[TEMPDATA_KEY]! ?? string.Empty;

            return result;
        }

        [HttpPost("PostData")]
        public IActionResult PostData([FromBody] PostModel Model)
        {
            var resultString = $"[from tempdata] {Model.Data}";
            TempData.Add(TEMPDATA_KEY, resultString);

            return Ok();
        }

        [HttpGet("PeekData")]
        public string PeekData()
        {
            string result = (string)TempData.Peek(TEMPDATA_KEY)! ?? string.Empty;

            return result;
        }
    }
}
