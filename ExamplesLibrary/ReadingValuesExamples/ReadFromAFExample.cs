using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF;
using OSIsoft.AF.Asset;

namespace ExamplesLibrary
{
    /// <summary>
    /// Retrieving values from AF Attributes is best done in bulk, in particular, if any of the data is coming from the PI Data Archive. 
    /// By bulk retrieving the data, the number of round-trips to the PI Data Archive are reduced.
    /// This example uses the AFAttributeList to illustrate how to retrieve attribute values in bulk.
    /// We will retrieve the current vaues for the Process Feedrate and Steam Flow attributes for all Compressor template elements and print to console.
    /// This example is very similar to the PartialLoadElementsExample.
    /// </summary>
    public class ReadFromAFExample : IExample
    {
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];

            AFDatabase afDatabase = piSystem.Databases["NuGreen"];
            if (afDatabase != null)
            {
                AFElementTemplate boilerTemplate = afDatabase.ElementTemplates["Compressor"];

                const int pageSize = 1000;
                int startindex = 0;
                int totalCount;
                do
                {
                    // Find a collection of elements instantiated from the Boiler tempplate.
                    // Only the Elements' header information (Name, Description, Template, Type, etc.)
                    // are loaded from the AF Server by this call.
                    AFNamedCollection<AFElement> elements = AFElement.FindElements(
                        database: afDatabase,
                        searchRoot: null,
                        query: "Compressor",
                        field: AFSearchField.Template,
                        searchFullHierarchy: true,
                        sortField: AFSortField.Name,
                        sortOrder: AFSortOrder.Ascending,
                        startIndex: startindex,
                        maxCount: pageSize,
                        totalCount: out totalCount);
                    if (elements == null) break;

                    // Partially load the element by retrieving information only for the Water Flow attribute.
                    AFElement.LoadAttributes(elements, new[] {
                        boilerTemplate.AttributeTemplates["Process Feedrate"], boilerTemplate.AttributeTemplates["Steam Flow"],
                    });

                    Console.WriteLine("Found {0} Elements.", elements.Count);

                    // Create an AFAttributeList object in order to make the bulk call later.
                    AFAttributeList attrList = new AFAttributeList();

                    // Because we are retrieving attributes which were previously loaded,
                    // no additional server calls are made.
                    // If LoadAttributes had not been called previously, then a server call would have been made for each element
                    // in the loop below.
                    foreach (AFElement item in elements)
                    {
                        attrList.Add(item.Attributes["Process Feedrate"]);
                        attrList.Add(item.Attributes["Steam Flow"]);
                    }

                    // MAKE A BULK CALL TO THE PI SERVER
                    AFValues values = attrList.GetValue();

                    Console.WriteLine("  Water Flow values");
                    foreach (AFValue val in values)
                    {
                        Console.WriteLine("  Element: {0}, Attribute: {1}",
                            val.Attribute.Element, val.Attribute, val.Timestamp, val.Value.ToString());
                        Console.WriteLine("    Timestamp: {0}, Value: {1}",
                            val.Timestamp, val.Value.ToString());
                    }

                    startindex += pageSize;

                } while (startindex < totalCount);

            }

        }

    }
}
