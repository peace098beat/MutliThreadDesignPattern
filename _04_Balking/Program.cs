using System;
using System.Threading.Tasks;

namespace _04_Balking
{
    class Program
    {
        static void Main(string[] args)
        {
			Data data = new Data("data.txt", "START");

			Task.Run(() => new ChangerThread(nameof(ChangerThread), data).Run());
			Task.Run(() => new SaverThread(nameof(SaverThread), data).Run());

			Console.ReadKey();
		}
    }
}