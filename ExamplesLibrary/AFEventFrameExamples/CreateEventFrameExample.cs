using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.EventFrame;
using OSIsoft.AF.Time;

namespace ExamplesLibrary
{
    public class CreateEventFrameExample : IExample
    {
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];

            AFDatabase afDatabase = piSystem.Databases["Basic-AFSDK-Sample"];

            CreateEventFrameTemplate(afDatabase);
            CreateEventFrames(afDatabase);
        }

        private void CreateEventFrameTemplate(AFDatabase afDatabase)
        {
            AFElementTemplate efTemplate = afDatabase.ElementTemplates.Add("BasicEventFrameTemplate");
            // Specify that this is an Event Frame Template.
            efTemplate.InstanceType = typeof(AFEventFrame);

            AFAttributeTemplate tempAttr = efTemplate.AttributeTemplates.Add("Maximum temperature");
            tempAttr.DataReferencePlugIn = AFDataReference.GetPIPointDataReference(afDatabase.PISystem);

            AFAttributeTemplate pressAttr = efTemplate.AttributeTemplates.Add("Maximum pressure");
            pressAttr.DataReferencePlugIn = AFDataReference.GetPIPointDataReference(afDatabase.PISystem);

            tempAttr.ConfigString = @".\Elements[.]|Temperature;TimeMethod=NotSupported;TimeRangeMethod=Maximum";
            pressAttr.ConfigString = @".\Elements[.]|Pressure;TimeMethod=NotSupported;TimeRangeMethod=Maximum";

            // Do a bulk check in of all changes made so far.
            afDatabase.CheckIn();
        }

        private void CreateEventFrames(AFDatabase afDatabase)
        {
            AFElementTemplate efTemplate = afDatabase.ElementTemplates["BasicEventFrameTemplate"];
            for (int i = 0; i < 5; i++)
            {
                AFEventFrame ef = new AFEventFrame(afDatabase, "EF_" + i, efTemplate);
                ef.SetStartTime(new AFTime(string.Format("t-{0}d", i + 1)));
                ef.SetEndTime(new AFTime(string.Format("t-{0}d", i)));

                AFElement element = afDatabase.Elements["Region_0"].Elements["BoilerA"];
                ef.PrimaryReferencedElement = element;
            }

            // Do a bulk check in of all changes made so far.
            afDatabase.CheckIn();
        }
    }
}
