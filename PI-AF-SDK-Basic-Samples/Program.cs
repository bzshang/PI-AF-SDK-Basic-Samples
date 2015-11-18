using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExamplesLibrary;


namespace PI_AF_SDK_Basic_Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            IExample example = new FindAttributesByPathExample();
            example.Run();

            Console.WriteLine();
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }
    }
}
