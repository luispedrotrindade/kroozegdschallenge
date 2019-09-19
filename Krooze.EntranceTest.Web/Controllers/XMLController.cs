using Krooze.EntranceTest.WriteHere.Tests.LogicTests;
using Microsoft.AspNetCore.Mvc;

namespace Krooze.EntranceTest.Web.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class XMLController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            var xmlTest = new XMLTest();
            var result = xmlTest.TranslateXML();

            return new JsonResult(result);
        }

    }
}