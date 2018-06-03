using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMLab1
{
    public class Generator
    {
        LinkedList<Task> tasks;
        int[,] edges;
        int[] solutionTime;
        int processor;
        LinkedList<Processor> Processors;
        int modelTime;

        public void generateSteps()
        {
            for (int i = 0; i < solutionTime.Length; i++)
            {
                Task temp = new Task(tasks.Count(), solutionTime[i]);
                Console.WriteLine(((tasks.Count())+"  solutionTime=" + temp.getSolutionTime()));
                tasks.AddLast(temp);
            }
            for (;checkEnd() ;)
            {
                generateStep();
            }
            //endTime = queue.getModelTime();
            Console.WriteLine("END ");
        }

        private void generateStep()
        {
            Console.WriteLine(modelTime);
            for (int i = 0; i < Processors.Count(); i++)
            {
                if ((!Processors.ElementAt(i).getFree())&&Processors.ElementAt(i).getEndTime() <= modelTime) {
                    Processors.ElementAt(i).setFree();
                    tasks.ElementAt(Processors.ElementAt(i).getTask()).setEndTime(tasks.ElementAt(Processors.ElementAt(i).getTask()).getEntranceTime()+ tasks.ElementAt(Processors.ElementAt(i).getTask()).getSolutionTime());
                    tasks.ElementAt(Processors.ElementAt(i).getTask()).setDone();
                    Console.WriteLine("Processor " + i + " finished task " + Processors.ElementAt(i).getTask());
                }
            }
            int nextModelTime = Int32.MaxValue;
            for (int i = 0; i < processor; i++) {
                if (Processors.ElementAt(i).getFree()) {
                    int id = getTask();
                    if (id != -1) {
                        Console.WriteLine("Processor " + i + " started task " + id);
                        Processors.ElementAt(i).setTask(id,modelTime+ tasks.ElementAt(id).getSolutionTime());
                        tasks.ElementAt(id).setEntranceTime(modelTime);
                        int time = tasks.ElementAt(id).getEntranceTime() + tasks.ElementAt(id).getSolutionTime();
                        if (time < nextModelTime)
                        {
                            nextModelTime = time;
                        }
                    }
                }
                else {
                    int time =tasks.ElementAt(Processors.ElementAt(i).getTask()).getEntranceTime() + tasks.ElementAt(Processors.ElementAt(i).getTask()).getSolutionTime();
                    if (time < nextModelTime) {
                        nextModelTime = time;
                    }
                }
            }
            if (nextModelTime == Int32.MaxValue)
            {
                nextModelTime = modelTime + 1;
            }
            modelTime = nextModelTime;
        }

        public Generator(int[,] edges, int[] solutionTime, int processors)
        {
            tasks = new LinkedList<Task>();
            this.edges = edges;
            this.solutionTime = solutionTime;
            processor = processors;
            Processors = new LinkedList<Processor>();
            for (int i = 0; i < processor; i++) {
                Processors.AddLast(new Processor());
            }
        }

        public bool checkEnd() {
            for (int i = 0; i < tasks.Count(); i++) {
                if (!tasks.ElementAt(i).getDone()) {
                    return true;
                }
            }
            return false;
        }

        public LinkedList<Task> GetTasks() {
            return tasks;
        }

        private int getTask() {
            bool found = false;
            for (int i = 0; i < tasks.Count(); i++) {
                if (!(tasks.ElementAt(i).getDone()|| (tasks.ElementAt(i).getEntranceTime()!=-1))) {
                    found = true;
                    for (int j = 0; j < solutionTime.Count(); j++) {
                        if (edges[j, i] != -1)
                        {
                            if (tasks.ElementAt(j).getDone() != true) {
                                found = false;
                                break; 
                            }
                            if (modelTime < (edges[j, i] + tasks.ElementAt(j).getEndTime()))
                            {
                                found = false;
                                break; 
                            }
                        }
                    }
                }
                if (found) {
                    return i;
                }
            }
            return -1;
        }
    }
}
