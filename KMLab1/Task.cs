using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMLab1
{
    public class Task
    {
        int taskNumber;
        int entranceTime;
        int solutionTime;
        int endTime;
        bool done;

        public int getTaskNumber()
        {
            return taskNumber ; 
        }

        public Task(int taskNumber, int solutionTime)
        {
            this.taskNumber = taskNumber;
            this.solutionTime = solutionTime;
            entranceTime = -1;
            done = false;
        }

        public int getEntranceTime()
        {
            return entranceTime;
        }

        public int getEndTime()
        {
            return endTime;
        }

        public bool getDone()
        {
            return done;
        }

        public int getSolutionTime()
        {
            return solutionTime;
        }

        public void setEntranceTime(int entranceTime)
        {
            this.entranceTime=entranceTime;
        }

        public void setEndTime(int endTime)
        {
            this.endTime = endTime;
        }

        public void setDone()
        {
            done = true;
        }
    }
}
