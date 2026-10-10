using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystemSimulator
{
    public class CPU
    {
        public int quantumTime;
        public int quantumCounter;
        public Process executingProcess;


        public CPU(int quantumTime)
        {
            this.quantumTime = quantumTime;
            this.quantumCounter = 0;
        }

        public void LoadProcess(Process p)
        {
            executingProcess = p;
            quantumCounter = 0;
            p.state = State.RUNNING;
        }
        public Process unloadProcess()
        {
            var p=executingProcess;
            executingProcess = null;
            return p;
        }

        public bool IsIdle()
        {
            return executingProcess == null;
        }


        public void Execute(
            Action<Process> onFinish,
            Action<Process> onQuantumExpired,
            Action<Process> onBlock)
        {
            if (executingProcess == null) return;
            executingProcess.Proceed();
            executingProcess.timeInRunning++;
            quantumCounter++;

            if (executingProcess.finished())
            {
                executingProcess.state = State.FINISHED;
                onFinish(unloadProcess());
            }
            else if(new Random().Next(0, 10) < 2)
            {
                executingProcess.timeBlock =
                    new Random().Next(1, 21);

                executingProcess.state = State.BLOCKED;
                onBlock(unloadProcess());
            }
            else if (quantumCounter >= quantumTime)
            {
                executingProcess.state = State.READY;
                onQuantumExpired(unloadProcess());
            }
        }
    }
}
