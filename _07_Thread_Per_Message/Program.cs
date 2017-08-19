using System;

namespace _07_Thread_Per_Message
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("main BEGIN");

			var host = new Host();
			host.Request(10, 'A');
			host.Request(20, 'B');
			host.Request(30, 'C');

			Console.WriteLine("main END");

			Console.ReadKey();
        }
    }
}