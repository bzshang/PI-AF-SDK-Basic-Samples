using System;
using ExamplesLibrary;


namespace PI_AF_SDK_Basic_Samples
{
    /// <summary>
    /// Choose the example you want run by creating a new object of the example type.
    /// For instances, the example below runs the AFConnection example.
    /// Before running the examples, please replace the AF Server or PI Data Archive name with your own.
    /// </summary>
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
