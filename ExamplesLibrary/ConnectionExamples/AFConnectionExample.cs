using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF;
using OSIsoft.AF.Asset;

namespace ExamplesLibrary
{
    public class AFConnectionExample : IExample
    {
        public void Run()
        {
            ImplicitConnection();
            ExplicitConnection();
        }

        public void ImplicitConnection()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["AFServerName"];
            // At this point, no connection is made.

            AFAttribute afAttribute = AFAttribute.FindAttribute(@"NuGreen\NuGreen\Houston|Environment", piSystem);
            // Now a connection is made by first data access.
        }

        public void ExplicitConnection()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["AFServerName"];
            // At this point, no connection is made.

            piSystem.Connect();
            // Now a connection is made by explicit call.

            AFAttribute afAttribute = AFAttribute.FindAttribute(@"NuGreen\NuGreen\Houston|Environment", piSystem);
        }
    }
}
