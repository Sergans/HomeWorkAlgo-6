using System;

namespace Task_6_1
{
    public class Node
    {
        public int value { get; set; }
        public List<Edge> Edges = new List<Edge>();//Исходящие
    }
    public class Edge
    {
        public int Weight { get; set; }
        public Node Node { get; set; }


    }
    public class Graph
    {
        public List<Node> nodes = new List<Node>();
    }
        class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
