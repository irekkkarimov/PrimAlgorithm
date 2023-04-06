using System;
using System.Collections.Generic;

namespace PrimAlgorithm;
public class PrimAlgorithm 
{
    public int V;  // Число вершин графа
    public int[][] graph;  // Матрица смежности для графа
    public long Iterations { get; private set; } // Счетчик итераций

    public PrimAlgorithm(int[][] g) 
    {
        V = g.Length;
        graph = g;
    }

    public int MinKey(int[] key, bool[] mstSet) 
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < V; v++)
        {
            Iterations++;
            if (!mstSet[v] && key[v] < min) 
            {
                min = key[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    public int[] PrimMST()  
    {
        int[] parent = new int[V];
        int[] key = new int[V];
        bool[] mstSet = new bool[V];
        int mstWeight = 0;

        for (int i = 0; i < V; i++) 
        {
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }

        key[0] = 0; // Начинаем с первой вершины
        parent[0] = -1;

        for (int count = 0; count < V - 1; count++) 
        {
            var u = MinKey(key, mstSet);

            mstSet[u] = true;

            for (int v = 0; v < V; v++)
            {
                Iterations++;
                if (graph[u][v] != 0 && !mstSet[v] && graph[u][v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u][v];
                    
                }
            }
        }

        return parent;
    }
}