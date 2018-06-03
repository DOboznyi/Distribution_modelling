using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMLab1
{
    class Processor
    {
        int taskNumber;
        int endTime;
        bool free;
        public Processor() {
            free = true;
        }

        public void setTask(int taskNumber, int endTime) {
            this.endTime = endTime;
            this.taskNumber = taskNumber;
            free = false;
        }

        public bool getFree() {
            return free;
        }

        public void setFree()
        {
            free = true;
        }

        public int getTask()
        {
            return taskNumber;
        }

        public int getEndTime()
        {
            return endTime;
        }
    }
}
