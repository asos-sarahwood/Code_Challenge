using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeChallengeSolution
{
    class Program
    {
        static void Main()
        {
            string logFile = @"C:\git\Code_Challenge\log.file";
            var lineCount = File.ReadLines(logFile).Count();

            Console.WriteLine(lineCount);
            Console.ReadLine();
     /*       using (FileStream fs = File.OpenRead(logFile))
            {
               byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    var lineCount = File.ReadLines(logFile).Count();
                    
                    Console.WriteLine(lineCount);
                    Console.ReadLine();
                }

            }*/
                                   
        }
    }
}
