using Krooze.EntranceTest.WriteHere.Structure.Model;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class SimpleLogicTest
    {
        public decimal? GetOtherTaxes(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, gets if there is some other tax that not the port charge

            decimal? result = null;

            if (cruise.CabinValue > 0 && cruise.PortCharge > 0)
                result = cruise.TotalValue - (cruise.CabinValue + cruise.PortCharge);

            return result;
        }

        public bool? IsThereDiscount(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, check if the second passenger has some kind of discount, based on the first passenger price
            //Assume there are always 2 passengers on the list

            return cruise.PassengerCruise[1].Cruise.CabinValue < cruise.PassengerCruise[0].Cruise.CabinValue;
        }

        public int? GetInstallments(decimal fullPrice)
        {
            //TODO: Based on the full price, find the max number of installments
            // -The absolute max number is 12
            // -The minimum value of the installment is 200
            int? totalInstalments = null;

            if(fullPrice > 0)
                totalInstalments = fullPrice >= 200 ? (int)fullPrice / 200 : 1;

            if (totalInstalments > 12)
                totalInstalments = 12;

            return totalInstalments;
        }
    }
}
