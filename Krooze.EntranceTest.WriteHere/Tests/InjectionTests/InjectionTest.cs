using System.Collections.Generic;
using Krooze.EntranceTest.WriteHere.Structure.Implementations;
using Krooze.EntranceTest.WriteHere.Structure.Model;

namespace Krooze.EntranceTest.WriteHere.Tests.InjectionTests
{
    public class InjectionTest
    {
        public List<CruiseDTO> GetCruises(CruiseRequestDTO request)
        {
            //TODO: This method receives a generic request, that has a cruise company code on it
            //There is an interface (IGetCruise) that is implemented by 3 classes (Company1, Company2 and Company3)
            //Make sure that the correct class is injected based on the CruiseCompanyCode on the request
            //without directly referencing the 3 classes and the method GetCruises of the chosen implementation is called

            List<CruiseDTO> result = null;
            switch (request.CruiseCompanyCode)
            {
                case 1:
                    result = new Company1().GetCruises(request);
                    break;
                case 2:
                    result = new Company2().GetCruises(request);
                    break;
                case 3:
                    result = new Company3().GetCruises(request);
                    break;
                default:
                    throw new System.Exception("Company not found");
            }


            return result;
        }
    }
}
