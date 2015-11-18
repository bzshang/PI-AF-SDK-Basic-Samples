using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.Time;

namespace ExamplesLibrary
{
    public class WriteValuesUsingAFExample : IExample
    {
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["BSHANG-PI1"];

            AFDatabase afDatabase = piSystem.Databases["Basic-AFSDK-Sample"];

            AFElement boilerA = afDatabase.Elements["Region_0"].Elements["BoilerA"];

            AFElementTemplate elementTemplate = afDatabase.ElementTemplates["BasicBoilerTemplate"];
            AFAttributeTemplate temperatureAttrTemplate = elementTemplate.AttributeTemplates["Temperature"];
            AFAttributeTemplate modeAttrTemplate = elementTemplate.AttributeTemplates["Mode"];
            AFElement.LoadAttributes(new[] { boilerA }, new[] { temperatureAttrTemplate, modeAttrTemplate });

            AFEnumerationSet digSet = afDatabase.EnumerationSets["Modes"];

            IList<AFValue> valuesToWrite = new List<AFValue>();
            for (int i = 0; i < 10; i++)
            {
                AFTime time = new AFTime(new DateTime(2015, 1, 1, i, 0, 0, DateTimeKind.Local));

                AFValue afValueFloat = new AFValue(i, time);
                // Associate the AFValue to an attribute so we know where to write to.
                afValueFloat.Attribute = boilerA.Attributes["Temperature"];

                AFEnumerationValue digSetValue = i % 2 == 0 ? digSet["Auto"] : digSet["Manual"];
                AFValue afValueDigital = new AFValue(digSetValue, time);
                afValueDigital.Attribute = boilerA.Attributes["Mode"];

                valuesToWrite.Add(afValueFloat);
                valuesToWrite.Add(afValueDigital);
            }

            // Perform a bulk write. Use a single local call to PI Buffer Subsystem if possible.
            // Otherwise, make a single call to the PI Data Archive.
            // We use no compression just so we can check all the values are written.
            // AFListData is the class that provides the bulk write method.
            AFListData.UpdateValues(valuesToWrite, AFUpdateOption.InsertNoCompression, AFBufferOption.BufferIfPossible);
        }
    }
}
