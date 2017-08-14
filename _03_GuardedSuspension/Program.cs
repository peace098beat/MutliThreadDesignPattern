using System;
using System.Threading.Tasks;

namespace _03_GuardedSuspension
{
    class Program
    {
        static void Main(string[] args)
        {
			var requestQueue = new RequestQueue();

			Task.Run(() => new ClientThread(requestQueue, "Alice", 12345).Run());
			Task.Run(() => new ServerThread(requestQueue, "Bobson", 98756).Run());

			Console.ReadKey();
        }
    }
}