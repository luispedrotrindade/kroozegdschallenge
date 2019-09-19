using Krooze.EntranceTest.WriteHere.Structure.Model;
using Krooze.EntranceTest.WriteHere.Tests.InjectionTests;
using Microsoft.AspNetCore.Mvc;

namespace Krooze.EntranceTest.Web.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class IncorrectInjectionController : ControllerBase
    {
        readonly InjectionTest _test = new InjectionTest();

        [HttpGet()]
        public ActionResult<string> Get()
        {
            var result = _test.GetCruises(new CruiseRequestDTO() { CruiseCompanyCode = 4 });
            return new JsonResult(result);
        }

    }
}