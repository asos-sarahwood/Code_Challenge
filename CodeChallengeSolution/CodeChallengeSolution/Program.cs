using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeChallengeSolution
{
    public class Program
    {
        public static void Main()
        {
            CalculateNumberOfLines();

            CalculateNumberOfComments();

        }

        public static void CalculateNumberOfLines()
        {
            string logFile = @"C:\git\Code_Challenge\log.file";

            var totalNumberOfLines = File.ReadLines(logFile).Count();
            Console.WriteLine("The total number of lines in the log file is " + totalNumberOfLines);
            Console.ReadLine();
        }

        public static void CalculateNumberOfComments()
        {
            int numberOfComments = 0;
            string logFile = @"C:\git\Code_Challenge\log.file";

            var totalNumberOfLines = File.ReadLines(logFile);
            foreach (var line in totalNumberOfLines)
            {
                if (line.StartsWith("#"))
                {
                    //Console.WriteLine("#");
                    numberOfComments++;

                }
                
            }

            Console.WriteLine("The total number of comments in the log file is " + numberOfComments);
            Console.ReadLine();

            // file.Close();


        }

    





      
    }
}
