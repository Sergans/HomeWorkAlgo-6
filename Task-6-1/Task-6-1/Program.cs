using System;
using System.Collections.Generic;

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
        public void AddNode(Node N)
        {
            nodes.Add(N);
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            Node node1 = new Node();
            Node node2 = new Node();
            Node node3 = new Node();
            Node node4 = new Node();

            Edge edge1 = new Edge();
            Edge edge2 = new Edge();
            Edge edge3 = new Edge();
            Edge edge4 = new Edge();

            Graph graph = new Graph();

            node1.value = 10;
            node2.value = 20;
            node3.value = 30;
            node4.value = 40;

            edge1.Weight = 5;
            edge2.Weight = 10;
            edge3.Weight = 15;
            edge4.Weight = 20;

            edge1.Node = node2;
            edge2.Node = node3;
            edge3.Node = node4;
            edge4.Node = node1;

            node1.Edges.Add(edge1);
            node2.Edges.Add(edge2);
            node3.Edges.Add(edge3);
            node4.Edges.Add(edge4);

            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);





        }
    }
}
