using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DijkstraAlgorithm
{
    class Dijkstra
    {
        public static int[] ShortestPathLength(int[,] Graph, int Source, int Destination, int NodesCount)
        {
            //Calculating the shortest path
            int[] Distance = new int[NodesCount];
            int minIndex = Source, Minimum, j;
            bool[] ShortestPathTreeSet = new bool[NodesCount];
            int[] Path = new int[NodesCount];
            for (int i = 0; i < NodesCount; i++)
            {
                Path[i] = Int32.MaxValue;
            }
            for (int i = 0; i < NodesCount; ++i)
            {
                Distance[i] = int.MaxValue;
                ShortestPathTreeSet[i] = false;
            }
            Distance[Source] = 0;
            for (int i = 0; i < NodesCount - 1; ++i)
            {
                for (j = 0; j < NodesCount; j++)
                {
                    if (Graph[minIndex, j] > 0 && Distance[j] > Distance[minIndex] + Graph[minIndex, j])
                    {
                        Distance[j] = Distance[minIndex] + Graph[minIndex, j];
                        Path[j] = minIndex;
                    }
                }
                ShortestPathTreeSet[minIndex] = true;
                Minimum = int.MaxValue;
                for (int v = 0; v < NodesCount; ++v)
                {
                    if (ShortestPathTreeSet[v] == false && Distance[v] <= Minimum)
                    {
                        Minimum = Distance[v];
                        minIndex = v;
                    }
                }
            }
            if (Distance[Destination] != Int32.MaxValue)
            {
                TracePath(Path, Destination);
                Console.WriteLine(Destination);
            }
            else
            {
                Console.WriteLine("Node Unavailable");
            }
            Console.WriteLine("Distance : " + Distance[Destination]);
            return Path;
        }
        public static void TracePath(int[] Path, int Destination)
        {
            if (Path[Destination] == Int32.MaxValue)
            {
                return;
            }
            TracePath(Path, Path[Destination]);
            Console.Write(Path[Destination] + "-->");
        }
        static void Main(string[] args)
        {
            int Source = 1, Destination = 13, NodesCount = 14;
            /* 
            Console.WriteLine("Enter Source :");
            Source = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Destination :");
            Destination = Int32.Parse(Console.ReadLine());
            */
            int[,] Graph = {
                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                         { 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                         { 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                         { 0, 2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                         { 0, 0, 0, 1, 0, 0, 6, 0, 0, 0, 0, 0, 8, 0},
                         { 0, 0, 3, 0, 0, 0, 1, 0, 0, 4, 0, 0, 0, 0},
                         { 0, 0, 0, 0, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                         { 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 1, 0, 3, 0},
                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3},
                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                         { 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 2, 0},
                    };
            ShortestPathLength(Graph, Source, Destination, NodesCount);
        }
    }
}