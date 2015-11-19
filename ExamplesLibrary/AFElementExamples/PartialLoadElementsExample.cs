using System;
using OSIsoft.AF;
using OSIsoft.AF.Asset;


namespace ExamplesLibrary
{
    /// <summary>
    /// Find and partially load a collection of elements instantiated from the Boiler template.
    /// Print the current values of the Water Flow attribute to the console.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
    public class PartialLoadElementsExample : IExample
    {
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];

            AFDatabase afDatabase = piSystem.Databases["NuGreen"];

            AFElementTemplate boilerTemplate = afDatabase.ElementTemplates["Boiler"];

            const int pageSize = 1000;
            int startIndex = 0;
            int totalCount;
            do
            {
                // Find a collection of elements instantiated from the Boiler tempplate.
                // Only the Elements' header information (Name, Description, Template, Type, etc.)
                // are loaded from the AF Server by this call.
                AFNamedCollection<AFElement> elements = AFElement.FindElements(
                    database: afDatabase,
                    searchRoot: null,
                    query: "Boiler",
                    field: AFSearchField.Template,
                    searchFullHierarchy: true,
                    sortField: AFSortField.Name,
                    sortOrder: AFSortOrder.Ascending,
                    startIndex: startIndex,
                    maxCount: pageSize,
                    totalCount: out totalCount);
                if (elements == null) break;

                // Partially load the element by retrieving information only for the Water Flow attribute.
                AFElement.LoadAttributes(elements, new[] { boilerTemplate.AttributeTemplates["Water Flow"] });

                Console.WriteLine("Found {0} Elements.", elements.Count);

                AFAttributeList attrList = new AFAttributeList();

                // Because we are retrieving the Water Flow attribute which was previously loaded,
                // no additional server calls are made.
                // If LoadAttributes had not been called previously, then a server call would have been made for each element
                // in the loop below.
                foreach (AFElement item in elements)
                {   
                    attrList.Add(item.Attributes["Water Flow"]);
                }

                AFValues values = attrList.GetValue();

                Console.WriteLine("  Water Flow values");
                foreach (AFValue val in values)
                {
                    Console.WriteLine("  Element: {0}, Timestamp: {1}, Value: {2}", 
                        val.Attribute.Element, val.Timestamp, val.Value.ToString());
                }

                startIndex += pageSize;

            } while (startIndex < totalCount);

        }


   
    }
}
