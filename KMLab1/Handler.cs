using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMLab1
{
    class Handler
    {
        Generator generator;
        double averageTimeRR;
        double dispersionRR;
        double relaxationTimeRR;
        double ratioRR;
        double currencyRR;
        double[,] Time = new double[2, 32];

        public Handler(int[,] edges,int[] solutionTime, int processors)
        {
            generator = new Generator(edges,solutionTime, processors);
        }

        public void generateSteps()
        {
            generator.generateSteps();
        }


        public void hand()
        {
            LinkedList<Task> tasks = generator.GetTasks();
        }
    }
}
