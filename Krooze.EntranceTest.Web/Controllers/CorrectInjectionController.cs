using Krooze.EntranceTest.WriteHere.Structure.Model;
using Krooze.EntranceTest.WriteHere.Tests.InjectionTests;
using Microsoft.AspNetCore.Mvc;

namespace Krooze.EntranceTest.Web.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CorrectInjectionController : ControllerBase
    {
        readonly InjectionTest _test = new InjectionTest();

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var result = _test.GetCruises(new CruiseRequestDTO() { CruiseCompanyCode = id });
            return new JsonResult(result);
        }

    }
}