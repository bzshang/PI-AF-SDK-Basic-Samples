using System;
using OSIsoft.AF;
using OSIsoft.AF.Asset;


namespace ExamplesLibrary
{
    public class BuildSimpleDatabaseExample : IExample
    {
        /// <summary>
        /// This example creates a sample AF database from basic element and attribute templates.
        /// </summary>
        /// <prerequisite-examples>
        /// none
        /// </prerequisite-examples>
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];

            AFDatabase afDatabase = piSystem.Databases.Add("Basic-AFSDK-Sample");

            CreateTemplates(afDatabase);
            CreateEnumerationSet(afDatabase);
            CreateElements(afDatabase);
            CreatePIPoints(afDatabase);
        }

        private void CreateTemplates(AFDatabase afDatabase)
        {
            AFElementTemplate elemTemplate = afDatabase.ElementTemplates.Add("BasicBoilerTemplate");

            AFAttributeTemplate attrTemplate_Temperature = elemTemplate.AttributeTemplates.Add("Temperature");
            AFAttributeTemplate attrTemplate_Pressure = elemTemplate.AttributeTemplates.Add("Pressure");
            AFAttributeTemplate attrTemplate_Limit = elemTemplate.AttributeTemplates.Add("Limit");
            AFAttributeTemplate attrTemplate_Mode = elemTemplate.AttributeTemplates.Add("Mode");

            attrTemplate_Temperature.Type = typeof(float);
            attrTemplate_Pressure.Type = typeof(float);
            attrTemplate_Limit.Type = typeof(string);

            AFEnumerationSet modes = afDatabase.EnumerationSets["Modes"];
            attrTemplate_Mode.TypeQualifier = modes;

            attrTemplate_Temperature.DataReferencePlugIn = AFDataReference.GetPIPointDataReference(afDatabase.PISystem);
            attrTemplate_Pressure.DataReferencePlugIn = AFDataReference.GetPIPointDataReference(afDatabase.PISystem);
            attrTemplate_Mode.DataReferencePlugIn = AFDataReference.GetPIPointDataReference(afDatabase.PISystem);

            attrTemplate_Temperature.ConfigString = @"%Database%.%..\Element%.%Element%.%Attribute%;ptclassname=classic;pointtype=float32;";
            attrTemplate_Pressure.ConfigString = @"%Database%.%..\Element%.%Element%.%Attribute%;ptclassname=classic;pointtype=float32;";
            attrTemplate_Mode.ConfigString = @"%Database%.%..\Element%.%Element%.%Attribute%;ptclassname=classic;pointtype=digital;digitalset=modes;";

            // Do a bulk check in of all changes made so far.
            afDatabase.CheckIn();
        }

        private void CreateEnumerationSet(AFDatabase afDatabase)
        {
            AFEnumerationSet modes = afDatabase.EnumerationSets.Add("Modes");
            modes.Add("Manual", 0);
            modes.Add("Auto", 1);
            modes.Add("Cascade", 2);
            modes.Add("Program", 3);
            modes.Add("Prog-Auto", 4);
        }

        private void CreateElements(AFDatabase afDatabase)
        {
            AFElementTemplate elemTemplate = afDatabase.ElementTemplates["BasicBoilerTemplate"];

            for (int i = 0; i < 5; i++)
            {
                AFElement element = afDatabase.Elements.Add("Region_" + i);
            }

            foreach (AFElement element in afDatabase.Elements)
            {
                AFElement childA = element.Elements.Add("BoilerA", elemTemplate);
                AFElement childB = element.Elements.Add("BoilerB", elemTemplate);

                childA.Attributes["Limit"].SetValue(new AFValue("10"));
                childB.Attributes["Limit"].SetValue(new AFValue("50"));
            }

            // Do a bulk check in of all changes made so far.
            afDatabase.CheckIn();
        }

        private void CreatePIPoints(AFDatabase afDatabase)
        {
            AFElementTemplate elemTemplate = afDatabase.ElementTemplates["BasicBoilerTemplate"];
            AFNamedCollectionList<AFBaseElement> baseElements = elemTemplate.FindInstantiatedElements(
                includeDerived: false,
                sortField: AFSortField.Name,
                sortOrder: AFSortOrder.Ascending,
                maxCount: 1000);

            foreach (AFBaseElement baseElement in baseElements)
            {
                int numModified = AFDataReference.CreateConfig(baseElement, false, null);
                Console.WriteLine("Modified or created: {0}", numModified);
            }
        }
    }
}
