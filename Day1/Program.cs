using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();
            var lists = GetListsFromFile("Input.txt");

            int distance = CalculateListsDistances(lists);
            int similarityScore = CalculateSimilarityScore(lists);

            timer.Stop();
            Console.WriteLine($"Operation completed in {timer.ElapsedMilliseconds}ms");
            Console.WriteLine($"The distance between the two lists is: {distance}");
            Console.WriteLine($"The similarity score between the two lists is: {similarityScore}");
            Console.ReadLine();
        }

        static List<int>[] GetListsFromFile(string fileName)
        {
            Console.WriteLine("Reading lists from: " + fileName);

            List<int>[] locationLists = { new List<int>(), new List<int>() };
            string[] splitters = new string[] { "   " };

            foreach (string line in File.ReadAllLines(fileName))
            {
                var splitLine = line.Split(splitters, StringSplitOptions.None);

                if (splitLine.Length > 1)
                {
                    locationLists[0].Add(int.Parse(splitLine[0]));
                    locationLists[1].Add(int.Parse(splitLine[1]));
                }
            }
            locationLists[0].Sort();
            locationLists[1].Sort();
            return locationLists;
        }

        private static int CalculateListsDistances(List<int>[] lists)
        {
            int distance = 0;

            for (int i = 0; i < lists[0].Count; i++)
            {
                distance += Math.Abs(lists[0][i] - lists[1][i]);
            }
            return distance;
        }

        private static int CalculateSimilarityScore(List<int>[] lists)
        {
            int similarityScore = 0;

            foreach (int num in lists[0])
            {
                similarityScore += num * lists[1].FindAll(x => x == num).Count;
            }
            return similarityScore;
        }

    }
}
