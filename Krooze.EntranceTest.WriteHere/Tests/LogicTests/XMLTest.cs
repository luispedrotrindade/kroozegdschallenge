using Krooze.EntranceTest.WriteHere.Structure.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class XMLTest
    {
        public CruiseDTO TranslateXML()
        {
            //TODO: Take the Cruises.xml file, on the Resources folder, and translate it to the CruisesDTO object,
            //you can do it in any way, including intermediary objects

            XElement xmlFile = XElement.Load("Resources/Cruises.xml");

            CruiseDTO result = new CruiseDTO
            {
                CruiseCode = xmlFile.Element("CruiseId").Value,
                TotalValue = Convert.ToDecimal(xmlFile.Element("TotalAllInclusiveCabinPrice").Value.Replace(".",",")),
                CabinValue = Convert.ToDecimal(xmlFile.Element("CabinPrice").Value.Replace(".", ",")),
                PortCharge = Convert.ToDecimal(xmlFile.Element("PortChargesAmt").Value.Replace(".", ",")),
                ShipName = xmlFile.Element("ShipName").Value,
                PassengerCruise = new List<PassengerCruiseDTO>()
            };

            XElement categoryPrice = xmlFile.Element("CategoryPriceDetails");

            IEnumerable<XElement> passengers = categoryPrice.Elements();


            foreach (XElement passenger in passengers)
            {
                result.PassengerCruise.Add(new PassengerCruiseDTO
                {
                    Cruise = new CruiseDTO {
                        CabinValue = Convert.ToDecimal(passenger.Elements("Charge").Where(x=>x.Attribute("ChargeType").Value == "CAB").First().Element("GrossAmount").Value.Replace(".", ",")),
                        PortCharge = Convert.ToDecimal(passenger.Elements("Charge").Where(x=>x.Attribute("ChargeType").Value == "PCH").First().Element("NetAmount").Value.Replace(".", ",")),
                        TotalValue = Convert.ToDecimal(passenger.Element("AllInclusivePerPax").Value.Replace(".", ","))                        
                    },
                    PassengerCode = passenger.FirstAttribute.Value
                });
            }

            return result;
        }

    }
}
