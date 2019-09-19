using Krooze.EntranceTest.WriteHere.Structure.Model;
using Krooze.EntranceTest.WriteHere.Tests.LogicTests;
using Microsoft.AspNetCore.Mvc;

namespace Krooze.EntranceTest.Web.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class OtherTaxesController : ControllerBase
    {
        readonly SimpleLogicTest _test = new SimpleLogicTest();

        [HttpGet("{cabinValue}/{portCharge}/{totalValue}")]
        public ActionResult<string> Get(decimal cabinValue, decimal portCharge, decimal totalValue)
        {

            var result = _test.GetOtherTaxes(new CruiseDTO()
            {
                CabinValue = cabinValue,
                PortCharge = portCharge,
                TotalValue = totalValue
            });
            return new JsonResult(result);
        }

    }
}