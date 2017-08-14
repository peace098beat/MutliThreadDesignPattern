using _03_GuardedSuspension.MsgQueTest;
using System;
using System.Threading.Tasks;

namespace _03_GuardedSuspension
{
    class Program
    {
        static void Main(string[] args)
        {
			RunMsgQueueTest();

			Console.ReadKey();
        }

		static void RunSample()
		{
			IResultQueue requestQueue = new RequestQueue2();

			Task.Run(() => new ClientThread(requestQueue, "Alice", 12345).Run());
			Task.Run(() => new ServerThread(requestQueue, "Bobson", 98756).Run());
		}

		static void RunMsgQueueTest()
		{
			Task.Run(() => new SenderSample("Asahi", 23456).Run());
			Task.Run(() => new SenderSample("Sapporo", 34211).Run());
			Task.Run(() => new ReceiverSample("Kirin", 1244).Run());
		}
    }
}