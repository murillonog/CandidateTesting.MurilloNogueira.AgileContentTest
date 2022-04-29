using CandidateTesting.MurilloNogueira.AgileContentTest.Util;
using System;
using System.Threading.Tasks;

namespace CandidateTesting.MurilloNogueira.AgileContentTest
{
    class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("Input an Url:");

            string url = Console.ReadLine();

            Console.WriteLine("Input a destination to file:");

            string path = Console.ReadLine();

            var request = new RequestLog();

            await request.GetLogAsync(url);

            if (string.IsNullOrEmpty(request.Log))
            {
                Console.WriteLine("The url did not return a log file");
            }

            var writer = new WriterFile();

            writer.WriteCdn(request.Log, path);

            if (!writer.Success)
            {
                Console.WriteLine($"There was an error writing the file: {writer.Error}");
            }
            else
            {
                Console.WriteLine("The file was successfully written");
            }            

            Console.ReadKey();
        }
    }
}
