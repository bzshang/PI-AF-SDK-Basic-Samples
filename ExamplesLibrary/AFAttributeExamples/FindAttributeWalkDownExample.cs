using System;
using OSIsoft.AF;
using OSIsoft.AF.Asset;


namespace ExamplesLibrary
{
    /// <summary>
    /// This example "walks-down" the AF hierarchy to locate an attribute of interest and then get its current value.
    /// The target attribute is \\Server\NuGreen\NuGreen\Houston\Cracking Process\Equipment\B-210|Process Feedrate.
    /// There are more direct methods to find this attribute, but this example is merely to demonstrate the behavior of
    /// some basic operations.
    /// Contrast this example with DirectLocateExample.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
    public class FindAttributeWalkDownExample : IExample
    {
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];

            AFDatabase afDatabase = piSystem.Databases["NuGreen"];

            AFElement nuGreen = afDatabase.Elements["NuGreen"];
            AFElement houston = nuGreen.Elements["Houston"];
            AFElement crackingProcess = houston.Elements["Cracking Process"];
            AFElement equipment = crackingProcess.Elements["Equipment"];
            AFElement b210 = equipment.Elements["B-210"];

            AFAttribute processFeedRate = b210.Attributes["Process Feedrate"];

            AFValue val = processFeedRate.GetValue();

            Console.WriteLine("Timestamp: {0}, Value: {1}", val.Timestamp, val.Value.ToString());
        }
    }
}
