using System;
using OSIsoft.AF;
using OSIsoft.AF.Asset;


namespace ExamplesLibrary
{
    /// <summary>
    /// Find a collection of elements instantiated from the Boiler template.
    /// Print each found element name to the console.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
    public class FindElementsExample : IExample
    {
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];

            AFDatabase afDatabase = piSystem.Databases["NuGreen"];

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

                // Because we are just retrieving the element's name, no additional calls
                // to the AF Server are made.
                Console.WriteLine("Found {0} Elements.", elements.Count);
                foreach (AFElement item in elements)
                {
                    Console.WriteLine("  Element name is {0}.", item.Name);
                }

                startIndex += pageSize;

            } while (startIndex < totalCount);
         
        }

    }
}
