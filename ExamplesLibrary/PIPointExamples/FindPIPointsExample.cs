using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.PI;
using OSIsoft.AF.Search;

namespace ExamplesLibrary
{
    /// <summary>
    /// This example finds PI Points based off of a query and prints the point attributes to the console.
    /// </summary>
    public class FindPIPointsExample : IExample
    {
        public void Run()
        {
            PIServers piServers = new PIServers();
            PIServer piServer = piServers["BSHANG-PI1"];

            // Use PICommonPointAttributes so we don't have to remember the strings for point attributes.
            PIPointQuery compressionFilter = new PIPointQuery {
                AttributeName = PICommonPointAttributes.Compressing,
                AttributeValue = "1",
                Operator = AFSearchOperator.Equal };

            PIPointQuery nameFilter = new PIPointQuery
            {
                AttributeName = PICommonPointAttributes.PointSource,
                AttributeValue = "R",
                Operator = AFSearchOperator.Equal
            };

            IEnumerable<string> attributesToLoad = new[]
            {
                PICommonPointAttributes.Compressing,
                PICommonPointAttributes.Descriptor,
                PICommonPointAttributes.PointSource,
                PICommonPointAttributes.Span,
                PICommonPointAttributes.Zero
            };

            IEnumerable<PIPoint> points = PIPoint.FindPIPoints(piServer, new[] { compressionFilter, nameFilter }, attributesToLoad);

            foreach (PIPoint pt in points)
            {
                Console.WriteLine("Name: {0}", pt.GetAttribute(PICommonPointAttributes.Tag));
                Console.WriteLine("Compressing: {0}", pt.GetAttribute(PICommonPointAttributes.Compressing));
                Console.WriteLine("Descriptor: {0}", pt.GetAttribute(PICommonPointAttributes.Descriptor));
                Console.WriteLine("PointSource: {0}", pt.GetAttribute(PICommonPointAttributes.PointSource));
                Console.WriteLine("Span: {0}", pt.GetAttribute(PICommonPointAttributes.Span));
                Console.WriteLine("Zero: {0}", pt.GetAttribute(PICommonPointAttributes.Zero));
                Console.WriteLine();
            }           
        }
    }
}
