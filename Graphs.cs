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
    
            // g.DFS(2);

            var d = new ShortestPath ();
            d.TryDijkstra ();
        }

        // Dijkstra’s
        // http://www.geeksforgeeks.org/greedy-algorithms-set-6-dijkstras-shortest-path-algorithm/
        class ShortestPath
        {
            static int V = 9;

            int MinDistance (int[] dist, bool[] sptSet)
            {
                int min = Int32.MaxValue;
                int minIndex = -1;

                for (int i = 0; i < V; i++)
                {
                    if (sptSet[i] == false && dist[i] < min)
                    {
                        min = dist[i];
                        minIndex = i;
                    }    
                }

                return minIndex;
            }

            // A utility function to print the constructed distance array
            void PrintSolution(int[] dist, int n)
            {
                Console.WriteLine("Vertex   Distance from Source");
                for (int i = 0; i < V; i++)
                    Console.WriteLine ( i + " \t\t " + dist[i]);
            }

            void Dijkstra (int[,] graph, int src)
            {
                // The output array. dist[i] will hold
                // the shortest distance from src to i
                int[] dist = new int[V];
            
                // sptSet[i] will true if vertex i is included in shortest
                // path tree or shortest distance from src to i is finalized  
                bool[] sptSet = new bool[V];

                for (int i = 0; i < V; i++)
                {
                    sptSet[i] = false;
                    dist[i] = Int32.MaxValue;
                } 

                // Distance of source vertex from itself is always 0
                dist[src] = 0;

                for (int count = 0; count < V - 1; count++)
                {
                    // Pick the minimum distance vertex from the set of vertices
                    // not yet processed. u is always equal to src in first
                    // iteration.
                    int u = MinDistance (dist, sptSet);
        
                    // Mark the picked vertex as processed
                    sptSet[u] = true;       

                    for (int i = 0; i < V; i++)
                    {
                        // Update dist[v] only if is not in sptSet, there is an
                        // edge from u to v, and total weight of path from src to
                        // v through u is smaller than current value of dist[v]                        
                        if (!sptSet[i] && 
                            graph[u, i] != 0 && 
                            dist[u] != Int32.MaxValue && 
                            dist[u] + graph[u, i] < dist[i])
                        {
                            dist[i] = dist[u] + graph[u,i];
                        }
                    }           
                }

                PrintSolution (dist, V);
            } 

            public void TryDijkstra ()
            {
                /* Let us create the example graph discussed above */
                int[,]  graph = new int[,] {{0, 4, 0, 0, 0, 0, 0, 8, 0},
                                        {4, 0, 8, 0, 0, 0, 0, 11, 0},
                                        {0, 8, 0, 7, 0, 4, 0, 0, 2},
                                        {0, 0, 7, 0, 9, 14, 0, 0, 0},
                                        {0, 0, 0, 9, 0, 10, 0, 0, 0},
                                        {0, 0, 4, 14, 10, 0, 2, 0, 0},
                                        {0, 0, 0, 0, 0, 2, 0, 1, 6},
                                        {8, 11, 0, 0, 0, 0, 1, 0, 7},
                                        {0, 0, 2, 0, 0, 0, 6, 7, 0}
                                        };
                Dijkstra (graph, 0);
            }            
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