using System;
using System.Collections.Generic;
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
            ReadMaximumTimeTaken();
            ReadMinimumTimeTaken();
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
                    numberOfComments++;
                }              
            }
            Console.WriteLine("The total number of comments in the log file is " + numberOfComments);
            Console.ReadLine();
        }

        public static void ReadMaximumTimeTaken()
        {
            string logFile = @"C:\git\Code_Challenge\log.file";
            var totalNumberOfLines = File.ReadLines(logFile);
            List<int> timeTakenList = new List<int>();

            foreach (var line in totalNumberOfLines)
            {
                if (line.StartsWith("2018"))
                {
                    int timeTaken = Convert.ToInt32(line.Split(' ').Last());
                    timeTakenList.Add(timeTaken);
                }
            }

            int maximumTimeTaken = timeTakenList.Max();
            Console.WriteLine("The maximum time taken was " + maximumTimeTaken);
            Console.ReadLine();
        }

        public static void ReadMinimumTimeTaken()
        {
            string logFile = @"C:\git\Code_Challenge\log.file";
            var totalNumberOfLines = File.ReadLines(logFile);
            List<int> timeTakenList = new List<int>();

            foreach (var line in totalNumberOfLines)
            {
                if (line.StartsWith("2018"))
                {
                    int timeTaken = Convert.ToInt32(line.Split(' ').Last());
                    timeTakenList.Add(timeTaken);
                }
            }

            int minimumTimeTaken = timeTakenList.Min();
            Console.WriteLine("The minumum time taken was " + minimumTimeTaken);
            Console.ReadLine();
        }

    }
}
