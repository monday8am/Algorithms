using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Graphs
    {
        public Graphs ()
        {
            Graph g = new Graph(4);
    
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);
    
            g.DFS(2);
        }

        class Graph 
        {
            private int vertices;
            private List<List<int>> adj;

            public Graph (int v)
            {
                vertices = v;
                adj = new List<List<int>> ();
                for (int i = 0; i < vertices; i++)
                {
                    adj.Add (new List<int> ());
                }
            }

            public void DFS (int v)
            {
                bool[] visited = new bool[vertices];
                DFSUtil (v, visited);
            } 

            public void AddEdge(int v, int w)
            {
                adj[v].Add (w);
            }    

            void DFSUtil (int v, bool[] visited)
            {
                visited[v] = true;

                // Do something with the node!!
                Console.WriteLine (v + " ");

                foreach (var item in adj[v])
                {
                    if (!visited[item])
                    {
                        DFSUtil (item, visited);
                    }
                }             
            }   
        }

        class Vertex 
        {
            public char Label; //Name of the vertex
            public bool Visited; //Visited marker of the vertex
            public Vertex(char label)
            {
                Label = label;
                Visited = false;
            }
        }   
    }             
}    