using Krooze.EntranceTest.WriteHere.Structure.Model;
using Krooze.EntranceTest.WriteHere.Tests.LogicTests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Krooze.EntranceTest.Web.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        readonly SimpleLogicTest _test = new SimpleLogicTest();

        [HttpGet("{firstPassenger}/{secondPassenger}")]
        public ActionResult<string> Get(decimal firstPassenger, decimal secondPassenger)
        {
            var result = _test.IsThereDiscount(new CruiseDTO()
            {
                PassengerCruise = new List<PassengerCruiseDTO>()
                {
                    new PassengerCruiseDTO()
                        {PassengerCode = "1", Cruise = new CruiseDTO() {CabinValue = firstPassenger}},
                    new PassengerCruiseDTO()
                        {PassengerCode = "2", Cruise = new CruiseDTO() {CabinValue = secondPassenger}},
                },
                CabinValue = firstPassenger + secondPassenger
            });
            return new JsonResult(result);
        }

    }
}