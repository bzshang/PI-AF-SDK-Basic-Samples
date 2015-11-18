using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF;
using OSIsoft.AF.PI;
using OSIsoft.AF.Asset;

namespace ExamplesLibrary
{
    public class PIConnectionExample : IExample
    {
        public void Run()
        {
            ImplicitConnection();
            ExplicitConnection();
        }

        public void ImplicitConnection()
        {
            PIServers piServers = new PIServers();
            PIServer piServer = piServers["PIServerName"];
            // At this point, no connection is made.

            PIPoint piPoint = PIPoint.FindPIPoint(piServer, "sinusoid");
            // Now a connection is made by first data access.
        }

        public void ExplicitConnection()
        {
            PIServers piServers = new PIServers();
            PIServer piServer = piServers["PIServerName"];
            // At this point, no connection is made.

            piServer.Connect();
            // Now a connection is made by explicit call.

            PIPoint piPoint = PIPoint.FindPIPoint(piServer, "sinusoid");
        }
    }
}
