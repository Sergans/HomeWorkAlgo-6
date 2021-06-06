using System;
using System.Collections.Generic;

namespace Task_6_1
{
    public class Node
    {
        public int value { get; set; }
        public List<Edge> Edges = new List<Edge>();//Исходящие
        public int status { get; set; }
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
        public int[,] Matrix()
        {
            var a = new int[nodes.Count, nodes.Count];
            for (int i = 0; i < nodes.Count; i++)
            {
                foreach (Edge b in nodes[i].Edges)
                {
                    for (int j = 0; j < nodes.Count; j++)
                    {
                        if (b.Node == nodes[j])
                        {
                            a[i, j] = b.Weight;
                        }
                    }
                }


            }

            return a;
        }
    }
        class Program
    {
        public static void FronStatBfs(Node node, int value)
        {
            Queue<Node> queue = new Queue<Node>();
            var a = node;
            a.status = 2;
            queue.Enqueue(a);
            while (queue.Count!=0)
            {
                if (queue.Peek().value == value)
                {
                    Console.WriteLine("Найдено");
                    break;
                }
                else
                {

                    if (queue.Peek().status == 2)
                    {

                        foreach (Edge f in queue.Peek().Edges)
                        {
                            if (f.Node.status != 3)
                            {
                                queue.Enqueue(f.Node);
                                f.Node.status = 2;
                            }


                        }

                        //queue.Dequeue();
                        Console.WriteLine($"Узел- {queue.Peek().value}- не найдено");
                        queue.Dequeue().status = 3;
                    }



                }

            }
           



        }

        static void Main(string[] args)
        {
            Node node1 = new Node();
            Node node2 = new Node();
            Node node3 = new Node();
            Node node4 = new Node();
            Node node5 = new Node();
            Node node6 = new Node();

            Edge edge1 = new Edge();
            Edge edge2 = new Edge();
            Edge edge3 = new Edge();
            Edge edge4 = new Edge();
            Edge edge5 = new Edge();
            Edge edge6 = new Edge();
            Edge edge7 = new Edge();
            Edge edge8 = new Edge();

            Graph graph = new Graph();

            node1.value = 10;
            node2.value = 20;
            node3.value = 30;
            node4.value = 40;
            node5.value = 50;
            node6.value = 60;

            edge1.Weight = 5;
            edge2.Weight = 10;
            edge3.Weight = 15;
            edge4.Weight = 20;
            edge5.Weight = 30;
            edge6.Weight = 5;
            edge7.Weight = 70;
            edge8.Weight = 1;

            edge1.Node = node2;
            edge2.Node = node5;
            edge3.Node = node3;
            edge4.Node = node4;
            edge5.Node = node5;
            edge6.Node = node1;
            edge7.Node = node6;
            edge8.Node = node4;//3 v 4
            

            node1.Edges.Add(edge1);
            node2.Edges.Add(edge3);
            node2.Edges.Add(edge4);
            node4.Edges.Add(edge5);
            node1.Edges.Add(edge5);
            node2.Edges.Add(edge6);
            node5.Edges.Add(edge7);
            node3.Edges.Add(edge8);


            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);
            graph.AddNode(node5);
            graph.AddNode(node6);

            var a = graph.Matrix();

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "|");
                }
                Console.WriteLine();



            }
            FronStatBfs(node1, 40);
        }
    }
}
