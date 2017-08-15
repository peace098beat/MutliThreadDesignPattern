using System;
using System.Threading;
using System.Threading.Tasks;

namespace _05_Producer_Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
			var table = new Table(3);   // ケーキ３個までおけるテーブル
			var cts = new CancellationTokenSource();
			var token = cts.Token;

			Task.Run(() => new MakerThread(nameof(MakerThread) + "-1", table, 12345).Run(token));
			Task.Run(() => new MakerThread(nameof(MakerThread) + "-2", table, 23456).Run(token));
			Task.Run(() => new MakerThread(nameof(MakerThread) + "-3", table, 34567).Run(token));

			Task.Run(() => new EaterThread(nameof(EaterThread) + "-1", table, 45678).Run(token));
			Task.Run(() => new EaterThread(nameof(EaterThread) + "-2", table, 56789).Run(token));
			Task.Run(() => new EaterThread(nameof(EaterThread) + "-3", table, 67890).Run(token));

			Thread.Sleep(4000);

			cts.Cancel();

			Console.ReadKey();
        }
    }
}