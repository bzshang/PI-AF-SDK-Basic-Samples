using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.PI;
using OSIsoft.AF.Time;


namespace ExamplesLibrary
{
    public class WriteValuesUsingPIExample : IExample
    {
        public void Run()
        {
            PIServers piServers = new PIServers();
            PIServer piServer = piServers["BSHANG-PI1"];

            IList<PIPoint> points = PIPoint.FindPIPoints(piServer, new[] { "sample_floatpoint", "sample_digitalpoint" });

            PIPoint floatingPIPoint = points[0];
            PIPoint digitalPIPoint = points[1];

            AFEnumerationSet digSet = piServer.StateSets["Modes"];

            IList<AFValue> valuesToWrite = new List<AFValue>();
            for (int i = 0; i < 10; i++)
            {
                AFTime time = new AFTime(new DateTime(2015, 1, 1, i, 0, 0, DateTimeKind.Local));

                AFValue afValueFloat = new AFValue(i, time);
                // Associate the AFValue to a PI Point so we know where to write to.
                afValueFloat.PIPoint = floatingPIPoint;

                AFEnumerationValue digSetValue = i % 2 == 0 ? digSet["Auto"] : digSet["Manual"];
                AFValue afValueDigital = new AFValue(digSetValue, time);
                afValueDigital.PIPoint = digitalPIPoint;

                valuesToWrite.Add(afValueFloat);
                valuesToWrite.Add(afValueDigital);
            }

            // Perform a bulk write. Use a single local call to PI Buffer Subsystem if possible.
            // Otherwise, make a single call to the PI Data Archive.
            // We use no compression just so we can check all the values are written.
            piServer.UpdateValues(valuesToWrite, AFUpdateOption.InsertNoCompression, AFBufferOption.BufferIfPossible);

        }
    }
}
