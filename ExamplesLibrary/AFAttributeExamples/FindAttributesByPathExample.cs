using System;
using OSIsoft.AF;
using OSIsoft.AF.Asset;


namespace ExamplesLibrary
{
    /// <summary>
    /// This example locates an attribute of interest and then get its current value.
    /// The target attribute is \\AFServer\NuGreen\NuGreen\Houston\Cracking Process\Equipment\B-210|Process Feedrate.
    /// The alternative is traversing down the AF hierarchy, as shown in HierarchyWalkDownExample.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
    public class FindAttributesByPathExample : IExample
    {
        public void Run()
        {
            string processFeedRate = @"\\<AFSERVER>\NuGreen\NuGreen\Houston\Cracking Process\Equipment\B-210|Process Feedrate";
            string waterFlow = @"\\<AFSERVER>\NuGreen\NuGreen\Houston\Cracking Process\Equipment\B-210|Water Flow";

            // Directly locate the AFAttribute of interest by passing in the AF path.
            // A similar method FindElementsByPath can be used to directly locate elements.
            AFKeyedResults<string,AFAttribute> results = AFAttribute.FindAttributesByPath(new[] { processFeedRate, waterFlow }, null);

            AFAttribute processFeedRateAttribute = results[processFeedRate];
            AFAttribute waterFlowAttribute = results[waterFlow];

            AFAttributeList attrList = new AFAttributeList(new[] { processFeedRateAttribute, waterFlowAttribute });
            // Make a bulk call to get values.
            AFValues values = attrList.GetValue();

            foreach (AFValue val in values)
            {
                Console.WriteLine("Attribute: {0}", val.Attribute);
                Console.WriteLine("Timestamp: {0}, Value: {1}", val.Timestamp, val.Value.ToString());
                Console.WriteLine();
            }          
        }
    }
}
