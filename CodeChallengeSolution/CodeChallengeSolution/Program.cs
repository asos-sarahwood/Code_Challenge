using System;
using System.Collections;
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
            BusiestHour();
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

        public static void BusiestHour()
        {
            
            List<string> timeTakenList = new List<string>();
            string logFile = @"C:\git\Code_Challenge\log.file";
            string[] splitBySpace;

            var totalNumberOfLines = File.ReadLines(logFile);

            foreach (var line in totalNumberOfLines)
            {
                if (line.StartsWith("2018"))
                {
                    splitBySpace = line.Split(' ');
                    string date = splitBySpace[0];
                    string timeStamp = splitBySpace[1];
                    timeTakenList.Add(timeStamp);
                }
            }

            string[] splitByColon;
            List<int> hourLoggedList = new List<int>();

            foreach (string time in timeTakenList)
            {
                splitByColon = time.Split(':');
                string hourLogged = splitByColon[0];
                hourLoggedList.Add(Convert.ToInt32(hourLogged));
            }

            var timeTakenGrouped = hourLoggedList.GroupBy(i => i);

            foreach (var hour in timeTakenGrouped)
            {
                var hourFromTimeStamp = hour.Key;
                var numberOfLogs = hour.Count();
                
                Console.WriteLine("the hour " + hourFromTimeStamp + " has " + numberOfLogs + " entries");
                Console.ReadLine();
            }

            
        }

    }
}
