using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BpmsApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class BpmsController : Controller
    {
        /// <summary>
        /// get a workflow including its nodes
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        [HttpGet]
        public IActionResult GetWorkflow(int id)
        {
            return Ok();
        }
    }
}
