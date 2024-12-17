using System;
using System.Collections.Generic;

class KruskalAlgorithm
{
    public class Edge : IComparable<Edge>
    {
        public int Source, Destination, Weight;
        public int CompareTo(Edge other) => this.Weight - other.Weight;
    }

    public static void KruskalMST(int vertices, List<Edge> edges)
    {
        // Sort edges by weight
        edges.Sort();

        int[] parent = new int[vertices];
        for (int i = 0; i < vertices; i++)
            parent[i] = i;

        List<Edge> mst = new List<Edge>();

        foreach (var edge in edges)
        {
            int rootSource = Find(parent, edge.Source);
            int rootDestination = Find(parent, edge.Destination);

            // If they are in different sets, include the edge in MST
            if (rootSource != rootDestination)
            {
                mst.Add(edge);
                Union(parent, rootSource, rootDestination);
            }

            // Stop when MST has enough edges
            if (mst.Count == vertices - 1)
                break;
        }

        // Print the MST
        Console.WriteLine("Edges in the MST:");
        foreach (var edge in mst)
            Console.WriteLine($"{edge.Source} -- {edge.Destination} == {edge.Weight}");
    }

    private static int Find(int[] parent, int node)
    {
        if (parent[node] != node)
            parent[node] = Find(parent, parent[node]);
        return parent[node];
    }

    private static void Union(int[] parent, int root1, int root2)
    {
        parent[root2] = root1;
    }

    public static void Main()
    {
        // Define the number of vertices
        int vertices = 4;

        // Define edges
        List<Edge> edges = new List<Edge>
        {
            new Edge { Source = 0, Destination = 1, Weight = 10 },
            new Edge { Source = 0, Destination = 2, Weight = 6 },
            new Edge { Source = 0, Destination = 3, Weight = 5 },
            new Edge { Source = 1, Destination = 3, Weight = 15 },
            new Edge { Source = 2, Destination = 3, Weight = 4 }
        };

        // Call the KruskalMST function
        KruskalMST(vertices, edges);
    }
}
