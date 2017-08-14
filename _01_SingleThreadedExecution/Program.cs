using System;
using System.Threading.Tasks;

namespace _01_SingleThreadedExecution
{
    class Program
    {
        static void Main(string[] args)
        {
			Gate gate = new Gate();

            Console.WriteLine("Threading Gate Start ...");

			Task.Run(() => new UserThread(gate, "Alithon", "Aichi").Run());
			Task.Run(() => new UserThread(gate, "Bobson", "Bousou").Run());
			Task.Run(() => new UserThread(gate, "Cheroky", "Canada").Run());

			Console.ReadKey();
		}
    }
}