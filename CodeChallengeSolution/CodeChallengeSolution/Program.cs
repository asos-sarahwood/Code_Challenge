using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeChallengeSolution
{
    public class BusiestHour
    {
        public int hour { get; set; }
        public int count { get; set; }
    }
    public class Program
    {
        public static string logFile = @"C:\git\Code_Challenge\log.file";
        public static void Main()
        {
            var totalNumberOfLines = CalculateNumberOfLines();
            var calculateNumberOfLinesMessage = $"The total number of lines in the log file is {totalNumberOfLines}";
            Console.WriteLine(calculateNumberOfLinesMessage);

            var numberOfComments = CalculateNumberOfComments();
            var numberOfCommentsMessage = $"The total number of comments in the log file is {numberOfComments}";
            Console.WriteLine(numberOfCommentsMessage);

            var maximumTimeTaken = ReadMaximumTimeTaken();
            var readMaximumTimeTakenMessage = $"The maximum time taken was {maximumTimeTaken}";
            Console.WriteLine(readMaximumTimeTakenMessage);

            var minimumTimeTaken = ReadMinimumTimeTaken();
            var readMinimumTimeTakenMessage = $"The minimum time taken was {minimumTimeTaken}";
            Console.WriteLine(readMaximumTimeTakenMessage);

            var busiestHour = BusiestHour();
            var busiestHourMessage = $"The busiest hour was {busiestHour.hour} with {busiestHour.count} entries";
            Console.WriteLine(busiestHourMessage);


            Console.ReadLine();
        }

        public static int CalculateNumberOfLines()
        {
            var totalNumberOfLines = File.ReadLines(logFile).Count();
            return totalNumberOfLines;
        }

        public static int CalculateNumberOfComments()
        {
            int numberOfComments = 0;
            var totalNumberOfLines = File.ReadLines(logFile);
            foreach (var line in totalNumberOfLines)
            {
                if (line.StartsWith("#"))
                {
                    numberOfComments++;
                }
            }
            return numberOfComments;
        }

        public static int ReadMaximumTimeTaken()
        {
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
            return maximumTimeTaken;
        }

        public static int ReadMinimumTimeTaken()
        {
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
            return minimumTimeTaken;
        }

        public static BusiestHour BusiestHour()
        {
            List<string> timeTakenList = new List<string>();
            string[] splitBySpace;
            var totalNumberOfLines = File.ReadLines(logFile);
            foreach (var line in totalNumberOfLines)
            {
                if (line.StartsWith("2018"))
                {
                    splitBySpace = line.Split(' ');
                    string timeStamp = splitBySpace[1];
                    timeTakenList.Add(timeStamp);
                }
            }
            List<int> hourLoggedList = new List<int>();
            string[] splitByColon;
            foreach (string time in timeTakenList)
            {
                splitByColon = time.Split(':');
                string hourLogged = splitByColon[0];
                hourLoggedList.Add(Convert.ToInt32(hourLogged));
            }
            var timeTakenGrouped = hourLoggedList.GroupBy(i => i);
            Dictionary<int, int> numberOfEntriesPerHour = new Dictionary<int, int>();
            foreach (var hour in timeTakenGrouped)
            {
                var hourFromTimeStamp = hour.Key;
                var totalNumberOfLogs = hour.Count();
                numberOfEntriesPerHour.Add(hourFromTimeStamp, totalNumberOfLogs);
            }

            var busiestHour = new BusiestHour()
            {
                hour = numberOfEntriesPerHour.OrderByDescending(x => x.Value).FirstOrDefault().Key,
                count = numberOfEntriesPerHour.OrderByDescending(x => x.Value).FirstOrDefault().Value
            };

            return busiestHour;
        }
    }
}
