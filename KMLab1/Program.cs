using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int processors = 6;
            int[,] edges = new int[15, 15];
            for (int i = 0; i < 15; i++) {
                for (int j = 0; j < 15; j++)
                {
                    edges[i, j] = -1;
                }
            }
            edges[0, 6] = 0;
            edges[1, 6] = 4;
            edges[1, 7] = 0;
            edges[2, 7] = 3;
            edges[3, 8] = 0;
            edges[4, 7] = 2;
            edges[4, 8] = 1;
            edges[4, 9] = 0;
            edges[5, 9] = 2;
            edges[5, 10] = 0;
            edges[6, 11] = 0;
            edges[6, 12] = 2;
            edges[7, 11] = 1;
            edges[7, 12] = 0;
            edges[8, 14] = 3;
            edges[9, 12] = 4;
            edges[10, 14] = 0;
            edges[11, 13] = 3;
            edges[12, 13] = 0;
            int[] solutionTime = new int[15] { 2, 3, 3, 1, 2, 1, 2, 4, 1, 2, 3, 2, 3, 2, 1 };
            Console.SetBufferSize(1000, Int16.MaxValue-1);
            Handler h = new Handler(edges, solutionTime, processors);
            h.generateSteps();
            h.hand();
            Console.ReadKey();
        }
    }
}
 