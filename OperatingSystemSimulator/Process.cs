using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystemSimulator
{
    public enum State
    {
        NEW,
        READY,
        RUNNING,
        BLOCKED,
        FINISHED
    }
    public class Process
    {
        public int PID, size, priority, programCounter = 0;
        public State state;
        public int timeBlock = 0;
        public int timeInNew = 0, timeInReady = 0, timeInRunning, timeInBlocked = 0;

        public Process (int PID, int size, int priority = 0)
        {
            this.PID = PID;
            this.size = size;
            this.priority = priority;
            this.state = State.NEW;
        }

        public void Proceed()
        {
            programCounter++;
        }

        public bool finished()
        {
            return programCounter >= size;
        }
        public override string ToString()
        {
            return $"PID:{PID}, Size:{size}, Priority:{priority}, PC{programCounter}";
        }

    }
}
