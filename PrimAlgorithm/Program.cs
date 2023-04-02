namespace PrimAlgorithm;
using System.Diagnostics;

public static class Program
{
    public static void Main()
    {
        
        int[][] graph =
        {
            new int[] { 0, 2, 0, 6, 0 },
            new int[] { 2, 0, 3, 8, 5 },
            new int[] { 0, 3, 0, 0, 7 },
            new int[] { 6, 8, 0, 0, 9 },
            new int[] { 0, 5, 7, 9, 0 }
        };

        var stopWatch = new Stopwatch();
        var arr = Initializer();
        
        // for (var i = 0; i < 50; i++)
        // {
        //     int[][] usedGraph;
        //     usedGraph = ConvertToMatrix(arr[i]);;
        //
        //     PrimAlgorithm mst = new PrimAlgorithm(usedGraph);
        //
        //     stopWatch.Start();
        //     int[] parent = mst.PrimMST();
        //     stopWatch.Stop();
        // }
        
        var singleUsedGraph = graph;;

        PrimAlgorithm mstSingle = new PrimAlgorithm(singleUsedGraph);

        stopWatch.Start();
        int[] parentSingle = mstSingle.PrimMST();
        stopWatch.Stop();

        Console.WriteLine("Edge   Weight");
        for (int i = 1; i < mstSingle.V; i++)
        {
            Console.WriteLine(parentSingle[i] + " - " + i + "    " + singleUsedGraph[i][parentSingle[i]]);
        }
        Console.WriteLine("------");
        Console.WriteLine($"Time elapsed : {stopWatch.Elapsed.Milliseconds}");
    }

    public static string[] Initializer()
    {
        var file = File.ReadAllText(@"C:\Users\Booba\Desktop\100_graphs_with_vertices_from_100_to_10000.txt");
        var arr = file.Split("\n\n\n");
        return arr;
    }

    public static int[][] ConvertToMatrix(string iGraph)
    {
        var firstEdges = iGraph.Split('\n');
        int[][] splittedEdges = new int[firstEdges.Length][];
        var max = int.MinValue;
        
        for (var i = 0; i < firstEdges.Length; i++)
        {
            var temp = firstEdges[i]
                .Replace("[", string.Empty)
                .Replace("]", string.Empty)
                .Split(", ");

            splittedEdges[i] = new int[] { int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]) };
            if (splittedEdges[i][0] > max || splittedEdges[i][1] > max)
                max = Math.Max(splittedEdges[i][0], splittedEdges[i][1]);
        }
        var verticesCount = 0;
        max++;
        
        int[][] matrix = new int[max][];
    
        for (var e = 0; e < max; e++)
            matrix[e] = new int[max];

        foreach (var line in splittedEdges)
        {
            matrix[line[0]][line[1]] = line[2];
            matrix[line[1]][line[0]] = line[2];
        }

        return matrix;
    }
}