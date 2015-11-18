using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.PI;

namespace ExamplesLibrary
{
    /// <summary>
    /// This example creates a floating and digital PI Point on the server.
    /// </summary>
    public class CreatePIPointsExample : IExample
    {
        public void Run()
        {
            PIServers piServers = new PIServers();
            PIServer piServer = piServers["BSHANG-PI1"];

            // Use PICommonPointAttributes so we don't have to remember the strings for point attributes.

            string floatpoint = "sample_floatpoint";
            Dictionary<string, object> floatpoint_attributes = new Dictionary<string, object>();
            floatpoint_attributes.Add(PICommonPointAttributes.PointClassName, "classic");
            floatpoint_attributes.Add(PICommonPointAttributes.Descriptor, "Hello floating world");
            floatpoint_attributes.Add(PICommonPointAttributes.PointType, "float32");

            string digitalpoint = "sample_digitalpoint";
            Dictionary<string, object> digitalpoint_attributes = new Dictionary<string, object>();
            digitalpoint_attributes.Add(PICommonPointAttributes.PointClassName, "classic");
            digitalpoint_attributes.Add(PICommonPointAttributes.Descriptor, "Hello digital world");
            digitalpoint_attributes.Add(PICommonPointAttributes.PointType, "digital");
            digitalpoint_attributes.Add(PICommonPointAttributes.DigitalSetName, "modes");

            Dictionary<string, IDictionary<string, object>> pointDict = new Dictionary<string, IDictionary<string, object>>();
            pointDict.Add(floatpoint, floatpoint_attributes);
            pointDict.Add(digitalpoint, digitalpoint_attributes);

            AFListResults<string, PIPoint> results = piServer.CreatePIPoints(pointDict);
        }
    }
}
