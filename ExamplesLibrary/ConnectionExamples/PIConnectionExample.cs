using OSIsoft.AF.PI;


namespace ExamplesLibrary
{
    /// <summary>
    /// This example demonstrates making a connection to an PI Data Archive using an implicit connection and an explicit connection.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
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
