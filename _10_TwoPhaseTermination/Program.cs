using System;
using System.Threading;

namespace _10_TwoPhaseTermination
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main: BEGIN");

            var t = new CountupThread();
            var task = t.Task();
            task.Start();

            Thread.Sleep(10000);

            Console.WriteLine("main: ShutdownRequest");
            t.ShutdownRequest();

            Console.WriteLine("main; join");
            task.Wait();

            Console.WriteLine("main: END");
            Console.ReadKey();
        }
    }
}
