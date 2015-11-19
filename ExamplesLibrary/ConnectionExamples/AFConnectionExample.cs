using OSIsoft.AF;
using OSIsoft.AF.Asset;


namespace ExamplesLibrary
{
    /// <summary>
    /// This example demonstrates making a connection to an AF Server using an implicit connection and an explicit connection.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
    public class AFConnectionExample : IExample
    {
        public void Run()
        {
            ImplicitConnection();
            ExplicitConnection();
        }

        private void ImplicitConnection()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];
            // At this point, no connection is made.

            AFAttribute afAttribute = AFAttribute.FindAttribute(@"NuGreen\NuGreen\Houston|Environment", piSystem);
            // Now a connection is made by first data access.
        }

        private void ExplicitConnection()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];
            // At this point, no connection is made.

            piSystem.Connect();
            // Now a connection is made by explicit call.

            AFAttribute afAttribute = AFAttribute.FindAttribute(@"NuGreen\NuGreen\Houston|Environment", piSystem);
        }
    }
}
