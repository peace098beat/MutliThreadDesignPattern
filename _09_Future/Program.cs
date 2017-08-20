using System;
using System.Threading;

namespace _09_Future
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main BEGIN !!");

            Host host = new Host();
            IData data1 = host.Request(10, 'A');
            IData data2 = host.Request(20, 'B');
            IData data3 = host.Request(30, 'C');

            Console.WriteLine("main other job BEGIN");
            Thread.Sleep(2000);
            Console.WriteLine("main other job END");

            Console.WriteLine("data1 = " + data1.GetContext());
            Console.WriteLine("data2 = " + data2.GetContext());
            Console.WriteLine("data3 = " + data3.GetContext());

            Console.WriteLine("main END !!");

            Console.ReadKey();
        }
    }
}
