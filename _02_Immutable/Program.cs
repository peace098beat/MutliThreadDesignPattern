using System;
using System.Threading.Tasks;

namespace _02_Immutable
{
    class Program
    {
        static void Main(string[] args)
        {
			var alice = new Person("Alice", "America");

			Task.Run(() => new PrintPersonThread(alice).Run());
			Task.Run(() => new PrintPersonThread(alice).Run());
			Task.Run(() => new PrintPersonThread(alice).Run());

			Console.ReadKey();
        }
    }
}