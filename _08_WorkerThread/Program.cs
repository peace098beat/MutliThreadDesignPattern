using System;
using System.Threading.Tasks;

namespace _08_WorkerThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel(5);   // ワーカスレッドの数
            channel.StartWorkers();

            Task.Run(() => new ClientThread("Alice", channel).Run());
            Task.Run(() => new ClientThread("Bobby", channel).Run());
            Task.Run(() => new ClientThread("Chris", channel).Run());

            Console.ReadKey();
        }
    }
}
