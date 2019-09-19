using Krooze.EntranceTest.WriteHere.Tests.WebTests;
using Microsoft.AspNetCore.Mvc;

namespace Krooze.EntranceTest.Web.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        readonly WebTest _test = new WebTest();

        [HttpGet]
        public ActionResult<string> Get()
        {
            var result = _test.GetDirector();

            return new JsonResult(result);
        }

    }
}