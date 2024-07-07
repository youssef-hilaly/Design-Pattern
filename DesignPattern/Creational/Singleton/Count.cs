using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Singleton
{
    public class Count
    {
        public int count = 0;
        private static Count instance = null;

        private static object instanceLock = new object();
        public void AddOne()
        {
            count++;
        }
        public static Count getInstance()
        {
            if(instance == null)
                lock (instanceLock)
                {
                    if (instance == null) { instance = new Count(); }
                }
            return instance;
        }
    }
    public class Singleton
    {
        public static void test()
        {
            // Example 1
            Count count1 = Count.getInstance();
            count1.AddOne();

            Count count2 = Count.getInstance();
            Console.WriteLine("Count2 " + count2.count);

            //Example 2
            Task task1 = Task.Factory.StartNew(() => {
                Count count1 = Count.getInstance();
                count1.AddOne();
                Console.WriteLine("Count1 " + count1.count);
            });

            Task task2 = Task.Factory.StartNew(() => {
                Count count2 = Count.getInstance();
                count2.AddOne();
                Console.WriteLine("Count2 " + count2.count);
            });
        }
    }
}
