using Krooze.EntranceTest.WriteHere.Structure.Model;
using System.Data;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;

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
                CruiseCode = xmlFile.Element("ConfigCode").Value
            };

            return result;
        }

    }
}
