using Krooze.EntranceTest.WriteHere.Tests.LogicTests;
using Microsoft.AspNetCore.Mvc;

namespace Krooze.EntranceTest.Web.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentsController : ControllerBase
    {
        readonly SimpleLogicTest _test = new SimpleLogicTest();

        [HttpGet("{fullPrice}")]
        public ActionResult<string> Get(decimal fullPrice)
        {
            var result = _test.GetInstallments(fullPrice);

            return new JsonResult(result);
        }

    }
}