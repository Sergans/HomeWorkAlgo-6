﻿using System;
using System.Collections.Generic;

namespace Task_6_1
{
    public class Node
    {
        public int value { get; set; }
        public List<Edge> Edges = new List<Edge>();//Исходящие
        public int status { get; set; }
        public bool visit;
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
        public static void FrontStatDFS(Node node, int value)
        {
            List<Node> visit = new List<Node>();
            Stack<Node> stack = new Stack<Node>();
            var a = node;
            stack.Push(a);
            while (stack.Count!=0)
            {
                if (stack.Peek().value == value)
                {
                    Console.WriteLine("Найдено");
                    break;

                }
                else
                {
                    if (stack.Peek().visit == false)
                    {
                        if (stack.Peek().Edges.Count != 0)
                        {
                            stack.Peek().visit = true;
                            Console.WriteLine($"Узел- {stack.Peek().value}- не найдено");

                            foreach (Edge stat in stack.Peek().Edges)
                            {
                                if (stat.Node.visit == false)
                                {
                                    stack.Push(stat.Node);
                                }
                                
                            }
                        }
                        else
                        {
                            stack.Peek().visit = true;
                            stack.Pop();
                        }
                       

                    }
                    else
                    {
                        stack.Pop();
                    }
                    


                }




            }
                
                //else
                //{
                //if (node.Edges.Count != 0&&node.visit==false)
                //{
                //    foreach (Edge stat in node.Edges)
                //    {
                        
                //        FrontStatDFS(stat.Node, value);
                //        stat.Node.visit = true;


                //    }
                //}

                        

                //}
            //}
          
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
            

            edge1.Node = node2;
            edge2.Node = node5;
            edge3.Node = node3;
            edge4.Node = node4;
            edge5.Node = node5;
            edge6.Node = node1;
            edge7.Node = node6;
           
            

            node1.Edges.Add(edge1);
            node2.Edges.Add(edge3);
            node2.Edges.Add(edge4);
            node4.Edges.Add(edge5);
            node1.Edges.Add(edge5);
            node2.Edges.Add(edge6);
            node5.Edges.Add(edge7);
           


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
            FronStatBfs(node1, 30);
            FrontStatDFS(node1, 30);
        }
    }
}
