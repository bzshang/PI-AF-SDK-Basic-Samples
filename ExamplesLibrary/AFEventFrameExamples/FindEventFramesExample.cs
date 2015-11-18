using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.EventFrame;

namespace ExamplesLibrary
{
    public class FindEventFramesExample : IExample
    {
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];

            AFDatabase afDatabase = piSystem.Databases["Basic-AFSDK-Sample"];

            const int pageSize = 1000;
            int startIndex = 0;
            int returnLimit = 100000;
            do
            {
                AFElementTemplate efTemplate = afDatabase.ElementTemplates["BasicEventFrameTemplate"];

                // Get event frames that started the past two days.
                AFNamedCollectionList<AFEventFrame> eventFrames = AFEventFrame.FindEventFrames(
                    database: afDatabase,
                    searchRoot: null,
                    startTime: "t-2d",
                    startIndex: startIndex,
                    maxCount: pageSize,
                    searchMode: AFEventFrameSearchMode.ForwardFromStartTime,
                    nameFilter: "*",
                    referencedElementNameFilter: "BoilerA",
                    elemCategory: null,
                    elemTemplate: efTemplate,
                    searchFullHierarchy: true);

                foreach (AFEventFrame ef in eventFrames)
                {
                    //Note: We should make a bulk call on the attribute values via AFAttributeList if we had many event frames.
                    Console.WriteLine("Name: {0}, Start: {1}, End: {2}, Max temp: {3}", 
                        ef.Name, ef.StartTime, ef.EndTime, ef.Attributes["Maximum temperature"].GetValue());
                }

                startIndex += pageSize;

            } while (startIndex < returnLimit);
        }
    }
}
