using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystemSimulator
{
    public class RandomProcessGenerartor
    {
        private int probability;
        private int pidCounter = 0;

        //constructor
        public RandomProcessGenerartor(int probability)
        {
            //Inicialization
            this.probability = probability;
        }
        public Process GetProcess()
        {
            if (new Random().Next(0, 100) < probability) {
                int size = new Random().Next(5, 15);
                int priority = new Random().Next(1, 6);

                return new Process(pidCounter++, size, priority);
            }
            return null;
        }
    }      
}
