using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystemSimulator
{
    public class OS
    {
        public List<Process> listNew =new List<Process>();
        public Queue<Process> listReady = new Queue<Process>();
        public List<Process> listBlocked = new List<Process>();
        public List<Process> listFinished= new List<Process>();
        public List<CPU> cpus =new List<CPU>();
        public RandomProcessGenerartor rpg;

        public OS(int cpuCount, int quantum, int creatProbability)
        {
            for (int i = 0; i < cpuCount; i++)
            {
                cpus.Add(new CPU(quantum));

                rpg = new RandomProcessGenerartor(creatProbability);
            }
        }
        public void clockTick()

        {
            int previousNewCount = listNew.Count;

            var newP = rpg.GetProcess();
            
            if (newP != null)
            {
                listNew.Add(newP);
            }
         

            for (int i=0; i<previousNewCount;i++)
            {
                Process p = listNew[0];

                listNew.RemoveAt(0);
                p.state = State.READY;
                listReady.Enqueue(p);                
            }
            for(int i = listBlocked.Count - 1; i >= 0; i--)
            {
                Process p=listBlocked[i];

                p.timeBlock--;
                p.timeInBlocked++;

                if (p.timeBlock <= 0)
                {
                    p.state=State.READY;
                    listReady.Enqueue(p);
                    listBlocked.RemoveAt(i);
                }

            }
            foreach(var cpu in cpus)
            {
                if(cpu.IsIdle()&& listReady.Count > 0)
                {
                    Process p = listReady.Dequeue();
                    cpu.LoadProcess(p);
                }
            }

            foreach (var cpu in cpus)
            {
                cpu.Execute(
                    onFinish: p => listFinished.Add(p),
                    onQuantumExpired: p => listReady.Enqueue(p),
                    onBlock: p => listBlocked.Add(p)
                    );

            }
            foreach (var cpu in cpus)
            {
                if (cpu.IsIdle() && listReady.Count > 0)
                {
                    Process p = listReady.Dequeue();
                    cpu.LoadProcess(p);
                }
            }
            listReady.ToList().ForEach(p => p.timeInReady++);
            listNew.ToList().ForEach(p => p.timeInNew++);
        }


    }
}
